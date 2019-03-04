using System;
using System.Collections.Generic;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace DomainLibrary.Model.Sql
{
    public partial class Block
    {
        public ObjectId Id { get; set; }
        public string Hash { get; set; }
        public int Height { get; set; }
        public int Confirmation { get; set; }
        public int Size { get; set; }
        public decimal Difficulty { get; set; }
        public byte Version { get; set; }
        public DateTime Time { get; set; }
        public string Json { get; set; }

        public static Block Map(Rpc.Block rpcBlock)
        {
            return new Block
            {
                Confirmation = rpcBlock.confirmations,
                Difficulty = Convert.ToDecimal(rpcBlock.difficulty),
                Hash = rpcBlock.hash,
                Height = rpcBlock.height,
                Size = rpcBlock.size,
                Time = Helper.UnixTimeStampToDateTime(rpcBlock.time),
                Version = Convert.ToByte(rpcBlock.version),
                Json = JsonConvert.SerializeObject(rpcBlock)
            };
        }
    }
}
