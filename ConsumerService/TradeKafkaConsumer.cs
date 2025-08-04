using Confluent.Kafka;
using Kafka.FastEndpoints.TradeStream.Domain.Models;
using Kafka.FastEndpoints.TradeStream.Domain.Interfaces;
using System.Text.Json;

namespace Kafka.FastEndpoints.TradeStream.ConsumerService;

public class TradeKafkaConsumer : BackgroundService
{
    private readonly IVWAPStore _vwapStore;
    private readonly string _topic;
    private readonly IConsumer<Ignore, string> _consumer;

    public TradeKafkaConsumer(IVWAPStore vwapStore, string bootstrapServers, string topic)
    {
        _vwapStore = vwapStore;
        _topic = topic;
        var config = new ConsumerConfig
        {
            GroupId = "trade-consumer-group",
            BootstrapServers = bootstrapServers,
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
        _consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        _consumer.Subscribe(_topic);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var cr = _consumer.Consume(stoppingToken);
                var trade = JsonSerializer.Deserialize<Trade>(cr.Message.Value);
                if (trade != null)
                {
                    _vwapStore.AddTrade(trade);
                }
            }
            catch (ConsumeException ex)
            {
                Console.WriteLine($"Kafka error: {ex.Error.Reason}");
            }
            await Task.Delay(10, stoppingToken); // basic backoff
        }
    }
}