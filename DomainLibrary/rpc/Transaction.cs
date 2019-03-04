namespace DomainLibrary.Model.Rpc
{
    public class Transaction
    {
        public string hex { get; set; }
        public string txid { get; set; }
        public int version { get; set; }
        public int locktime { get; set; }
        public TransactionInput[] vin { get; set; }
        public TransactionOutput[] vout { get; set; }
        public string blockhash { get; set; }
        public int confirmations { get; set; }
        public int time { get; set; }
        public int blocktime { get; set; }
    }
}