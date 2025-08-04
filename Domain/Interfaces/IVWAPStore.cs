using Kafka.FastEndpoints.TradeStream.Domain.Models;

namespace Kafka.FastEndpoints.TradeStream.Domain.Interfaces;

public interface IVWAPStore
{
    void AddTrade(Trade trade);
    decimal? GetVWAP(string symbol);
}