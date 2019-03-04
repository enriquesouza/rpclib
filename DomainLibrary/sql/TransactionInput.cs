using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace DomainLibrary.Model.Sql
{
    public partial class TransactionInput
    {
        public ObjectId Id { get; set; }
        public string TxidIn { get; set; }
        public short IndexIn { get; set; }
        public string TxidOut { get; set; }
        public short IndexOut { get; set; }
        public string Address { get; set; }
        public decimal Value { get; set; }
        public string Json  { get; set; }
    }
}
