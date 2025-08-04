using Xunit;
using Kafka.FastEndpoints.TradeStream.Domain.Models;
using Kafka.FastEndpoints.TradeStream.Domain.Services;

namespace Kafka.FastEndpoints.TradeStream.Tests;

public class VWAPStoreTests
{
    [Fact]
    public void CalculatesVWAPCorrectly()
    {
        var store = new VWAPStore();
        store.AddTrade(new Trade { Symbol = "AAPL", Price = 100, Quantity = 10 });
        store.AddTrade(new Trade { Symbol = "AAPL", Price = 110, Quantity = 5 });

        var vwap = store.GetVWAP("AAPL");
        Assert.Equal(103.33m, vwap, 2);
    }

    [Fact]
    public void ReturnsNullForNoTrades()
    {
        var store = new VWAPStore();
        var vwap = store.GetVWAP("MSFT");
        Assert.Null(vwap);
    }
}