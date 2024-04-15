using ChainBlockify.Application.DTOs.Blockcypher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChainBlockify.Application.DTOs.Blockcypher
{
    public class BlockchainInfoEthBlockcypherDto: BaseBlockchainInfoBlockcypherDto
    {
        public long HighGasPrice { get; set; }
        public long MediumGasPrice { get; set; }
        public long LowGasPrice { get; set; }
        public long HighPriorityFee { get; set; }
        public long MediumPriorityFee { get; set; }
        public long LowPriorityFee { get; set; }
        public long BaseFee { get; set; }
        [JsonConstructor]
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
