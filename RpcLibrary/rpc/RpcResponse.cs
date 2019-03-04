using System;

namespace RpcLibrary.Rpc
{
    public class RpcResponse<T>
    {
        public T result { get; set; }
        public string error { get; set; }
        public string id { get; set; }
    }
}