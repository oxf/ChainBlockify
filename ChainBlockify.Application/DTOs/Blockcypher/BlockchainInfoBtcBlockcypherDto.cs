using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChainBlockify.Application.DTOs.Blockcypher
{
    public record BlockchainInfoBtcBlockcypherDto : BaseBlockchainInfoBlockcypherDto
    {
        [JsonPropertyName("high_fee_per_kb")]
        private readonly int HighFeePerKB;
        [JsonPropertyName("medium_fee_per_kb")]
        private readonly int MediumFeePerKB;
        [JsonPropertyName("low_fee_per_kb")]
        private readonly int LowFeePerKB;

        [JsonConstructor]
        public BlockchainInfoBtcBlockcypherDto() { }
        public BlockchainInfoBtcBlockcypherDto(
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
            int HighFeePerKB,
            int MediumFeePerKB,
            int LowFeePerKB) : base(
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
            this.HighFeePerKB = HighFeePerKB;
            this.MediumFeePerKB = MediumFeePerKB;
            this.LowFeePerKB = LowFeePerKB;
        }
    }
}
