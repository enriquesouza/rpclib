using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace DomainLibrary.Model.Sql
{
    public partial class TransactionOutput
    {
        public ObjectId Id { get; set; }
        public string Txid { get; set; }
        public short Index { get; set; }
        public string Address { get; set; }
        public decimal Value { get; set; }
        public string Json  { get; set; }
    }
}
