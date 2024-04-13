using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChainBlockify.Application.DTOs.Blockcypher
{
    public record BaseBlockchainInfoBlockcypherDto: BaseBlockcypherDto
    {
        [JsonPropertyName("name")]
        private readonly string Name;

        [JsonPropertyName("height")]
        private readonly int Height;
        [JsonPropertyName("hash")]
        private readonly string Hash;
        [JsonPropertyName("time")]
        private readonly DateTime Time;
        [JsonPropertyName("latest_url")]
        private readonly string LatestUrl;
        [JsonPropertyName("previous_hash")]
        private readonly string PreviousHash;
        [JsonPropertyName("previous_url")]
        private readonly string PreviousUrl; 
        [JsonPropertyName("peer_count")]
        private readonly int PeerCount;
        [JsonPropertyName("unconfirmed_count")]
        private readonly int UnconfirmedCount;
        [JsonPropertyName("last_fork_height")]
        private readonly int LastForkHeight;
        [JsonPropertyName("last_fork_hash")]
        private readonly string LastForkHash;
        [JsonConstructor]
        public  BaseBlockchainInfoBlockcypherDto() { }
        public BaseBlockchainInfoBlockcypherDto(
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
        string LastForkHash
        )
        {
            this.Name = Name;
            this.Height = Height;
            this.Hash = Hash;
            this.Time = Time;
            this.LatestUrl = LatestUrl;
            this.PreviousHash = PreviousHash;
            this.PreviousUrl = PreviousUrl;
            this.PeerCount = PeerCount;
            this.UnconfirmedCount = UnconfirmedCount;
            this.LastForkHeight = LastForkHeight;
            this.LastForkHash = LastForkHash;
        }
    }
}
