using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace RpcLibrary.Rpc
{
    public class Rpc<T>
    {

        static string serverURL => GetConfiguration().GetValue<string>("Rpc:Server");
        static string serverUser => GetConfiguration().GetValue<string>("Rpc:User");
        static string serverPass => GetConfiguration().GetValue<string>("Rpc:Pass");
        static string connString => GetConfiguration().GetValue<string>("Data:ConnectionString");

        private static IConfigurationRoot GetConfiguration() => new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile($"appsettings.json", optional: true)
                            .Build();

        public static T GetT(RpcRequestBody requestBody)
        {
            //Authorization Header
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] bytesAuthValue = encoding.GetBytes(serverUser + ":" + serverPass);
            string base64AuthValue = Convert.ToBase64String(bytesAuthValue);
            string basicAuthValue = "Basic " + base64AuthValue;

            var jsonRequestBody = JsonConvert.SerializeObject(requestBody);
            byte[] bytesRequestBody = encoding.GetBytes(jsonRequestBody);

            //Post
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(serverURL);
            req.Method = "POST";
            req.ContentType = "application/json";
            req.Headers.Add("Authorization", basicAuthValue);

            Stream newStream = req.GetRequestStream();
            newStream.Write(bytesRequestBody, 0, bytesRequestBody.Length);
            newStream.Close();

            //Response
            HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    string responseString = reader.ReadToEnd();
                    var responseBlock = JsonConvert.DeserializeObject<RpcResponse<T>>(responseString);
                    if (responseBlock.error == null || responseBlock.error == "")
                    {
                        return responseBlock.result;
                    }
                    else
                    {
                        Console.WriteLine("Response Error" + responseBlock.error + " : " + jsonRequestBody);
                        throw new Exception();
                    }
                }
            }
            else
            {
                Console.WriteLine("HTTP Error" + response.StatusCode.ToString() + " : " + jsonRequestBody);
                throw new Exception();
            }
        }
        public static String GetString(RpcRequestBody requestBody)
        {
            try
            {
                //Authorization Header
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] bytesAuthValue = encoding.GetBytes(serverUser + ":" + serverPass);
                string base64AuthValue = Convert.ToBase64String(bytesAuthValue);
                string basicAuthValue = "Basic " + base64AuthValue;

                var jsonRequestBody = JsonConvert.SerializeObject(requestBody);
                byte[] bytesRequestBody = encoding.GetBytes(jsonRequestBody);

                //Post
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(serverURL);
                req.Method = "POST";
                req.ContentType = "application/json";
                req.Headers.Add("Authorization", basicAuthValue);

                Stream newStream = req.GetRequestStream();
                newStream.Write(bytesRequestBody, 0, bytesRequestBody.Length);
                newStream.Close();

                //Response
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                        string strReader = reader.ReadToEnd();
                        Console.WriteLine("O retorno do reader foi: {0}", strReader);
                        return strReader;
                    }
                }
                else
                {
                    Console.WriteLine("HTTP Error" + response.StatusCode.ToString() + " : " + jsonRequestBody);
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.Message);
            }
            return null;
        }
        public static string GetByUrl(string serverURL)
        {
            //Get
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(serverURL);
            req.Method = "GET";

            //Response
            HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    string responseString = reader.ReadToEnd();

                    return responseString;
                }
            }
            else
            {
                Console.WriteLine("HTTP Error" + response.StatusCode.ToString() + " : " + serverURL);
                throw new Exception();
            }
        }
    }
}