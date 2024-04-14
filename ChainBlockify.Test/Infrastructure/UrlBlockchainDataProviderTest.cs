using ChainBlockify.Application.Interfaces;
using ChainBlockify.Application.DTOs.Blockcypher;
using ChainBlockify.Domain.Entities;
using ChainBlockify.Infrastructure;
using Microsoft.Extensions.Logging;
using NSubstitute;
using RichardSzalay.MockHttp;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Net.Http.Headers;

namespace ChainBlockify.Test.Infrastructure
{
    public class UrlBlockchainDataProviderTest
    {
        private readonly MockHttpMessageHandler _handler = new();
        private readonly string _baseAddress = "https://api.blockcypher.com/v1/btc/main";

        public UrlBlockchainDataProviderTest()
        {
            
        }

        //[Fact]
        //public async Task GetBlockchainInfo_Success()
        //{
        //    // Arrange
        //    var mockLogger = Substitute.For<ILogger<UrlBlockchainInfoProvider<BlockchainInfoBtcBlockcypherDto>>>();
        //    var mockHttpClientFactory = Substitute.For<IHttpClientFactory>();
        //    //var mockDto = new BlockchainInfoBtcBlockcypherDto();
        //        //"a",
        //        //100,
        //        //"b",
        //        //new DateTime(2024, 4, 12, 1, 2, 3),
        //        //"c",
        //        //"d",
        //        //"e",
        //        //int.MaxValue,
        //        //int.MinValue,
        //        //101,
        //        //"f",
        //        //102,
        //        //103,
        //        //104
        //        //);
        //    string url = "https://api.blockcypher.com/v1/btc/main";
        //    var mockClient = new HttpClient(_handler)
        //    {
        //        BaseAddress = new Uri(_baseAddress),
        //    };
        //    mockHttpClientFactory.CreateClient().Returns(mockClient);
        //    _handler
        //        .Expect(HttpMethod.Get, _baseAddress)
        //       // .Respond(HttpStatusCode.OK, JsonContent.Create<BlockchainInfoBtcBlockcypherDto>(mockDto));
            
        //    // Act
        //    UrlBlockchainInfoProvider<BlockchainInfoBtcBlockcypherDto> provider = new UrlBlockchainInfoProvider<BlockchainInfoBtcBlockcypherDto>(mockLogger, mockHttpClientFactory);
        //    var dto = await provider.GetBlockchainInfo(url, CancellationToken.None);

        //    // Assert
        //    Assert.Equal(mockDto, dto);
        //}


        //[Fact]
        //public async Task GetBlockchainInfo_HandlesHttpRequestException()
        //{
            // Arrange
            //var logger = Substitute.For<ILogger<UrlBlockchainInfoProvider<BlockchainInfoBtcBlockcypherDto>>>();
            //var httpClient = Substitute.For<IHttpClientFactory>();
            //var baseUrl = "https://api.blockcypher.com/v1";
            //var currency = "btc";
            //var cancellationToken = CancellationToken.None;

            //var dataProvider = new UrlBlockchainInfoProvider<BlockchainInfoBtcBlockcypherDto>(logger, httpClient);

            //var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);

            ////httpClient.GetAsync(Arg.Any<string>(), Arg.Any<CancellationToken>())
            ////    .Returns(Task.FromResult(responseMessage));

            //// Act + Assert
            //await Assert.ThrowsAsync<HttpRequestException>(() => dataProvider.GetBlockchainInfo(currency, cancellationToken));
            //logger.Received().LogError(Arg.Any<string>());
        //}
    }
}