using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Domain
{
    public record BlockchainInfoEthBlockcypherDto: BaseBlockchainInfoBlockcypherDto
    {
        private readonly long HighGasPrice;
        private readonly long MediumGasPrice;
        private readonly long LowGasPrice;
        private readonly long HighPriorityFee;
        private readonly long MediumPriorityFee;
        private readonly long LowPriorityFee;
        private readonly long BaseFee;

        public BlockchainInfoEthBlockcypherDto(
            string Name,
            int Height,
            string Hash,
            DateTime Time,
            string LatestUrl,
            string PreviousHash,
            string PreviousUrl,
            int PeerCount,
            int UnconfirmedCount,
            int LastForkHeight,
            string LastForkHash,
            long HighGasPrice,
            long MediumGasPrice,
            long LowGasPrice,
            long HighPriorityFee,
            long MediumPriorityFee,
            long LowPriorityFee,
            long BaseFee) : base(
            Name,
            Height,
            Hash,
            Time,
            LatestUrl,
            PreviousHash,
            PreviousUrl,
            PeerCount,
            UnconfirmedCount,
            LastForkHeight,
            LastForkHash)
        {
            this.HighGasPrice = HighGasPrice;
            this.MediumGasPrice = MediumGasPrice;
            this.LowGasPrice = LowGasPrice;
            this.HighPriorityFee = HighPriorityFee;
            this.MediumPriorityFee = MediumPriorityFee;
            this.LowPriorityFee = LowPriorityFee;
            this.BaseFee = BaseFee;
        }
    }
}
