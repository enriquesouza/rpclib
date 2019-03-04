namespace DomainLibrary.Model.Rpc
{
    public class TransactionScriptPubKey
    {
        public string asm { get; set; }
        public string hex { get; set; }
        public int reqSigs { get; set; }
        public string type { get; set; }
        public string[] addresses { get; set; }
    }
}