namespace DomainLibrary.Model.Rpc
{
    public class TransactionOutput
    {
        public string TransactionId { get; set; }

        public string BlockHash { get; set; }

        public int n { get; set; }
        public TransactionScriptPubKey scriptPubKey { get; set; }
        //ADD
        public string Address { get; set; }

        public decimal value { get; set; }
    }
}