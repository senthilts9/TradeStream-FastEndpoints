namespace Kafka.FastEndpoints.TradeStream.Domain.Models;

public record Trade
{
    public string TradeId { get; init; }
    public string Symbol { get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; init; }
    public DateTime Timestamp { get; init; }
}