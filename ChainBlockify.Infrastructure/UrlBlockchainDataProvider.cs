using ChainBlockify.Application.Interfaces;
using ChainBlockify.Domain;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace ChainBlockify.Infrastructure
{
    public class UrlBlockchainDataProvider(
        ILogger<UrlBlockchainDataProvider> _logger,
        HttpClient _httpClient,
        string _baseUrl
    ) : IBlockchainInfoProvider
    {
        public async Task<BaseBlockchainInfo> GetBlockchainInfo(string currency, CancellationToken cancellationToken)
        {
            try
            {
                var url = $"{_baseUrl}/{currency}/main";
                var response = await _httpClient.GetAsync(url, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    using (var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken))
                    {
                        try
                        {
                            return await JsonSerializer.DeserializeAsync<BaseBlockchainInfo>(contentStream, cancellationToken: cancellationToken);
                        }
                        catch (JsonException ex)
                        {
                            _logger.LogError($"Failed to deserialize JSON response for {currency}. Error: {ex.Message}");
                            throw;
                        }
                    }
                }
                else
                {
                    throw new HttpRequestException($"Failed to fetch data for {currency}. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching blockchain info for {currency}");
                throw;
            }
        }
    }
}
