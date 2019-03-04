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

namespace RpcLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var blockCount = Convert.ToInt64(Rpc.RpcBlock.GetBlockCount());
            Console.WriteLine(blockCount);

            for (var i = 0; i <= blockCount; i++)
            {
                var blockHash = Rpc.RpcBlock.GetBlockHash(i);
                Console.WriteLine("Height: {0} - Hash: {1}", i, blockHash);

            }

            /*var blockInfo = Rpc.RpcBlock.GetBlock("00000009c4e61bee0e8d6236f847bb1dd23f4c61ca5240b74852184c9bf98c30");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(blockInfo));

            foreach (string transactionId in blockInfo.tx)
            {
                var transaction = Rpc.RpcTransaction.GetTransactionRaw(transactionId);

                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(transaction));
            }*/


            Console.ReadLine();
        }
    }
}
