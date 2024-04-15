using System.ComponentModel.DataAnnotations.Schema;

namespace ChainBlockify.Domain.Entities
{
    [Table("BlockchainBlockchainSource")]
    public class BlockchainBlockchainSource : BaseEntity
    {
        public string Url { get; set; }
        public string DtoName { get; set; }
        public Blockchain Blockchains { get; set; }
        public BlockchainSource BlockchainSource { get; set; }
    }
}
