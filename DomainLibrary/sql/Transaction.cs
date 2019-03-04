using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace DomainLibrary.Model.Sql
{
    public partial class Transaction
    {
        public ObjectId Id { get; set; }
        public string Txid { get; set; }
        public string BlockHash { get; set; }
        public byte Version { get; set; }
        public DateTime Time { get; set; }
        public string Json { get; set; }

        public static Transaction Map(Rpc.Transaction rpcTransaction)
        {
            return null;
            /*return new Transaction
            {
                Time = rpcTransaction.time,
                BlockHash = rpcTransaction.blockhash,
                Txid = rpcTransaction.txid,
                Version = rpcTransaction.version,
                Json = JsonConvert.SerializeObject(rpcTransaction)
            };*/
        }
    }
}
