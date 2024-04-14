using System.ComponentModel.DataAnnotations.Schema;

namespace ChainBlockify.Domain.Entities
{
    [Table("BlockchainSource")]
    public class BlockchainSource : BaseEntity
    {
        public string Name { get; set; }
    }
}
