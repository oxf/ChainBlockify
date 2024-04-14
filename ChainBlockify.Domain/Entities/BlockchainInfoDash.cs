using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Domain.Entities
{
    [Table("BlockchainInfoDash")]
    public class BlockchainInfoDash : BaseBlockchainInfo
    {
        public int HighFeePerKB { get; set; }
        public int MediumFeePerKB { get; set; }
        public int LowFeePerKB { get; set; }
    }
}
