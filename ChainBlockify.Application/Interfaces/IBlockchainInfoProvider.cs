using ChainBlockify.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Application.Interfaces
{
    public interface IBlockchainInfoProvider<DTO> 
    {
        /// <summary>
        /// Interface that retrieves the blockchain info from various sources
        /// </summary>
        /// <param name="url">URL of the API to download data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        public Task<DTO> GetBlockchainInfo(string url, CancellationToken cancellationToken);
    }
}
