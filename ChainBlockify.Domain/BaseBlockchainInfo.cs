using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Domain
{
    public abstract class BaseBlockchainInfo
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public string Hash { get; set; }
        public DateTime Time { get; set; }
        public string LatestUrl { get; set; }
        public string PreviousHash { get; set; }
        public string PreviousUrl { get; set; }
        public int PeerCount { get; set; }
        public int UnconfirmedCount { get; set; }
        public int LastForkHeight { get; set; }
        public string LastForkHash { get; set; }
    }
}
