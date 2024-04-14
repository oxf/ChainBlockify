using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Domain.Entities
{
    [Table("BlockchainInfoEth")]
    public class BlockchainInfoEth : BaseBlockchainInfo
    {
        public long HighGasPrice { get; set; }
        public long MediumGasPrice { get; set; }
        public long LowGasPrice { get; set; }
        public long HighPriorityFee { get; set; }
        public long MediumPriorityFee { get; set; }
        public long LowPriorityFee { get; set; }
        public long BaseFee { get; set; }
    }
}
