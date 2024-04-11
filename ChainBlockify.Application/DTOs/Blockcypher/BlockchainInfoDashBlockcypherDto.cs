﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Domain
{
    public record BlockchainInfoDashBlockcyptherDto: BaseBlockchainInfoBlockcypherDto
    {
        private readonly int HighFeePerKB;
        private readonly int MediumFeePerKB;
        private readonly int LowFeePerKB;
        public BlockchainInfoDashBlockcyptherDto(
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
            int LowFeePerKB): base(
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