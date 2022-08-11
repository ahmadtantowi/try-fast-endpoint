namespace TryFastEndpoint.Features;

public class RootHandler : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/");
        AllowAnonymous();
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        return SendOkAsync("Hello World", ct);
    }
}
