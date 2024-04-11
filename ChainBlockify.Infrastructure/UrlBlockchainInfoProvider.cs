using ChainBlockify.Application.Interfaces;
using ChainBlockify.Domain;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using System.Net.Http;

namespace ChainBlockify.Infrastructure
{
    /// <summary>
    /// Implementation of getting the blockchain info from API via HTTP
    /// </summary>
    /// <param name="_logger">Logger</param>
    /// <param name="_httpClient">Http client</param>
    public class UrlBlockchainInfoProvider<DTO>(
        ILogger<UrlBlockchainInfoProvider<DTO>> _logger,
        IHttpClientFactory _httpClientFactory
    ) : IBlockchainInfoProvider<DTO>
    {
        /// <summary>
        /// Download blockchain data from API via HTTP
        /// Possible errors: URL is not available; API didn't return success status; Failed to deserialize API response;
        /// </summary>
        /// <param name="url">URL of API to get</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<DTO> GetBlockchainInfo(string url, CancellationToken cancellationToken)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetFromJsonAsync<DTO>(url, cancellationToken);
                return response;
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request errors (e.g., network issues)
                _logger.LogError(ex, $"HTTP request error occurred while fetching blockchain info for {url}");
                throw;
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, $"JSON serialization/deserialization error occurred while fetching blockchain info for {url}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching blockchain info for {url}");
                throw;
            }
        }
    }
}
