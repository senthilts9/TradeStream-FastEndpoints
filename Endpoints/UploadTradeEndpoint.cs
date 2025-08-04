using FastEndpoints;
using Kafka.FastEndpoints.TradeStream.Domain.Models;
using Kafka.FastEndpoints.TradeStream.Domain.Interfaces;

namespace Kafka.FastEndpoints.TradeStream.Endpoints;

public class UploadTradeEndpoint : Endpoint<Trade>
{
    private readonly IVWAPStore _vwapStore;

    public UploadTradeEndpoint(IVWAPStore vwapStore)
    {
        _vwapStore = vwapStore;
    }

    public override void Configure()
    {
        Post("/trade/upload");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Trade req, CancellationToken ct)
    {
        _vwapStore.AddTrade(req);
        await SendAsync(req, cancellation: ct);
    }
}