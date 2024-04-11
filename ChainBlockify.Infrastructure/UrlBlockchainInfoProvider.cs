using ChainBlockify.Application.Interfaces;
using ChainBlockify.Domain;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace ChainBlockify.Infrastructure
{
    /// <summary>
    /// Implementation of getting the blockchain info from API via HTTP
    /// </summary>
    /// <param name="_logger">Logger</param>
    /// <param name="_httpClient">Http client</param>
    public class UrlBlockchainInfoProvider(
        ILogger<UrlBlockchainInfoProvider> _logger,
        HttpClient _httpClient
    ) : IBlockchainInfoProvider
    {
        /// <summary>
        /// Download blockchain data from API via HTTP
        /// Possible errors: URL is not available; API didn't return success status; Failed to deserialize API response;
        /// </summary>
        /// <param name="url">URL of API to get</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<BaseBlockchainInfo> GetBlockchainInfo(string url, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _httpClient.GetAsync(url, cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Failed to fetch data for {url}. Status code: {response.StatusCode}");
                }
                using (var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken))
                {
                    try
                    {
                        return await JsonSerializer.DeserializeAsync<BaseBlockchainInfo>(contentStream, cancellationToken: cancellationToken);
                    }
                    catch (JsonException ex)
                    {
                        _logger.LogError($"Failed to deserialize JSON response for {url}. Error: {ex.Message}");
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching blockchain info for {url}");
                throw;
            }
        }
    }
}
