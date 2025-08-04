using Kafka.FastEndpoints.TradeStream.Domain.Models;
using Kafka.FastEndpoints.TradeStream.Domain.Interfaces;
using System.Collections.Concurrent;

namespace Kafka.FastEndpoints.TradeStream.Domain.Services;

public class VWAPStore : IVWAPStore
{
    private readonly ConcurrentDictionary<string, List<Trade>> _tradesBySymbol = new();

    public void AddTrade(Trade trade)
    {
        var trades = _tradesBySymbol.GetOrAdd(trade.Symbol, _ => new List<Trade>());
        lock (trades)
        {
            trades.Add(trade);
        }
    }

    public decimal? GetVWAP(string symbol)
    {
        if (!_tradesBySymbol.TryGetValue(symbol, out var trades) || trades.Count == 0)
            return null;

        decimal totalNotional = 0;
        int totalQuantity = 0;

        foreach (var trade in trades)
        {
            totalNotional += trade.Price * trade.Quantity;
            totalQuantity += trade.Quantity;
        }

        return totalQuantity == 0 ? null : totalNotional / totalQuantity;
    }
}