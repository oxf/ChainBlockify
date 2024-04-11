using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChainBlockify.Domain
{
    public record BaseBlockchainInfoBlockcypherDto(
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
        );
}
