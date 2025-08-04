using Xunit;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Kafka.FastEndpoints.TradeStream.Domain.Models;

namespace Kafka.FastEndpoints.TradeStream.Tests;

public class UploadVWAPTradeTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public UploadVWAPTradeTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task PostTrade_ReturnsSuccess()
    {
        var trade = new Trade { Symbol = "AAPL", Quantity = 5, Price = 200 };
        var json = new StringContent(JsonSerializer.Serialize(trade), Encoding.UTF8, "application/json");

        var res = await _client.PostAsync("/trade/upload", json);
        res.EnsureSuccessStatusCode();
    }
}