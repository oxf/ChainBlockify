using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChainBlockify.Application.DTOs.Blockcypher
{
    public abstract class BaseBlockchainInfoBlockcypherDto: BaseBlockcypherDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }
        [JsonPropertyName("hash")]
        public string Hash { get; set; }
        [JsonPropertyName("time")]
        public DateTime Time { get; set; }
        [JsonPropertyName("latest_url")]
        public string LatestUrl { get; set; }
        [JsonPropertyName("previous_hash")]
        public string PreviousHash { get; set; }
        [JsonPropertyName("previous_url")]
        public string PreviousUrl { get; set; }
        [JsonPropertyName("peer_count")]
        public int PeerCount { get; set; }
        [JsonPropertyName("unconfirmed_count")]
        public int UnconfirmedCount { get; set; }
        [JsonPropertyName("last_fork_height")]
        public int LastForkHeight { get; set; }
        [JsonPropertyName("last_fork_hash")]
        public string LastForkHash { get; set; }
        public BaseBlockchainInfoBlockcypherDto(string name, int height, string hash, DateTime time, string latestUrl, string previousHash, string previousUrl, int peerCount, int unconfirmedCount, int lastForkHeight, string lastForkHash)
        {
            Name = name;
            Height = height;
            Hash = hash;
            Time = time;
            LatestUrl = latestUrl;
            PreviousHash = previousHash;
            PreviousUrl = previousUrl;
            PeerCount = peerCount;
            UnconfirmedCount = unconfirmedCount;
            LastForkHeight = lastForkHeight;
            LastForkHash = lastForkHash;
        }
    }
}
