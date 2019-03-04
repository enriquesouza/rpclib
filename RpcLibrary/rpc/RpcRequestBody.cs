using System;

namespace RpcLibrary.Rpc
{
    public class RpcRequestBody
    {
        public string method { get; set; }
        public object[] @params { get; set; }
    }
}