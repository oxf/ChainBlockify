using System.ComponentModel.DataAnnotations.Schema;

namespace ChainBlockify.Domain.Entities
{
    [Table("Blockchain")]
    public class Blockchain: BaseEntity
    {
        public string Name { get; set; }
        public List<BlockchainBlockchainSource> Sources { get; set; }
    }
}
