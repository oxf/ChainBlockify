﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChainBlockify.Application.DTOs.Blockcypher
{
    [Table("BlockchainInfoBtc")]
    public class BlockchainInfoBtcBlockcypherDto : BaseBlockchainInfoBlockcypherDto
    {
        [JsonPropertyName("high_fee_per_kb")]
        public int HighFeePerKB { get; set; }
        [JsonPropertyName("medium_fee_per_kb")]
        public int MediumFeePerKB { get; set; }
        [JsonPropertyName("low_fee_per_kb")]
        public int LowFeePerKB { get; set; }
        [JsonConstructor]
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
