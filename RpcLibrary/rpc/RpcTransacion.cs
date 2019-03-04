using System;
using System.IO;
using System.Net;
using System.Text;
using DomainLibrary.Model.Rpc;

namespace RpcLibrary.Rpc
{
    public static class RpcTransaction
    {
        public static Transaction GetTransactionRaw(string transactionid)
        {
            return Rpc<Transaction>.GetT(new RpcRequestBody
            {
                method = "getrawtransaction",
                @params = new object[] { transactionid, 1 }
            });
        }
    }
}