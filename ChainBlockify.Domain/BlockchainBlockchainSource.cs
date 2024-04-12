namespace ChainBlockify.Domain
{
    public class BlockchainBlockchainSource
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public Blockchain Blockchains { get; set; }
        public BlockchainSource BlockchainSource { get; set; }
    }
}
