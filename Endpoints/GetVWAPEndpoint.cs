using FastEndpoints;
using Kafka.FastEndpoints.TradeStream.Domain.Interfaces;

namespace Kafka.FastEndpoints.TradeStream.Endpoints;

public class GetVWAPEndpoint : Endpoint<GetVWAPRequest, GetVWAPResponse>
{
    private readonly IVWAPStore _vwapStore;

    public GetVWAPEndpoint(IVWAPStore vwapStore)
    {
        _vwapStore = vwapStore;
    }

    public override void Configure()
    {
        Get("/trade/vwap/{Symbol}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetVWAPRequest req, CancellationToken ct)
    {
        var vwap = _vwapStore.GetVWAP(req.Symbol);
        var res = new GetVWAPResponse
        {
            Symbol = req.Symbol,
            VWAP = vwap
        };
        await SendAsync(res, cancellation: ct);
    }
}

public class GetVWAPRequest
{
    public string Symbol { get; set; }
}

public class GetVWAPResponse
{
    public string Symbol { get; set; }
    public decimal? VWAP { get; set; }
}