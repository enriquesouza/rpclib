using DomainLibrary.Model.Rpc;

namespace RpcLibrary.Rpc
{
    public static class RpcBlock
    {
        public static string FisrtBlockHash = "00000009c4e61bee0e8d6236f847bb1dd23f4c61ca5240b74852184c9bf98c30";

        public static Block GetBlock(string blockHash)
        {
            return Rpc<Block>.GetT(new RpcRequestBody
            {
                method = "getblock",
                @params = new object[] { blockHash }
            });
        }
        public static string GetBlockHash(int index)
        {
            return Rpc<string>.GetT(new RpcRequestBody
            {
                method = "getblockhash",
                @params = new object[] { index }
            });
        }

        public static string GetBlockCount()
        {
            return Rpc<string>.GetT(new RpcRequestBody
            {
                method = "getblockcount",
                @params = new object[] {  }
            });
        }

    }
}