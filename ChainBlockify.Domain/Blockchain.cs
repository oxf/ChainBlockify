﻿namespace ChainBlockify.Domain
{
    public class Blockchain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BlockchainBlockchainSource> Sources { get; set;}
    }
}
