namespace DomainLibrary.Model.Rpc
{
    public class TransactionInput
    {
        public string coinbase { get; set; }
        public string txid { get; set; }
        public long vout { get; set; }
        public TransactionScriptSig scriptSig { get; set; }
        public long sequence { get; set; }

        //ADD
        public string Address { get; set; }

        public decimal value { get; set; }

        public int IndexInput { get; set; }

        public int IndexOutput { get; set; }
    }
}