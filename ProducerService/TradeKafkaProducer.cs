using Confluent.Kafka;
using Kafka.FastEndpoints.TradeStream.Domain.Models;
using System.Text.Json;

namespace Kafka.FastEndpoints.TradeStream.ProducerService;

public class TradeKafkaProducer
{
    private readonly IProducer<Null, string> _producer;
    private readonly string _topic;

    public TradeKafkaProducer(string bootstrapServers, string topic)
    {
        var config = new ProducerConfig { BootstrapServers = bootstrapServers };
        _producer = new ProducerBuilder<Null, string>(config).Build();
        _topic = topic;
    }

    public async Task ProduceAsync(Trade trade)
    {
        var json = JsonSerializer.Serialize(trade);
        await _producer.ProduceAsync(_topic, new Message<Null, string> { Value = json });
    }
}