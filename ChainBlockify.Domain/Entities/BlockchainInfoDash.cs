using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Domain.Entities
{
    public class BlockchainInfoDash : BaseBlockchainInfo
    {
        public int HighFeePerKB { get; set; }
        public int MediumFeePerKB { get; set; }
        public int LowFeePerKB { get; set; }
    }
}
