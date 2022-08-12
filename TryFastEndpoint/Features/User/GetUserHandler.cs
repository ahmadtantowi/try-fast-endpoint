namespace TryFastEndpoint.Features.User;

public class GetUserHandler : Endpoint<GetUserRequest, GetUserResult>
{
    public override void Configure()
    {
        Get("/user");
        Permissions("ReadUser");
        Policies(PolicyConstant.CustomerPolicy);
        ResponseCache(10);

        Summary(sum => sum.Summary = "Get User");
    }

    public override async Task HandleAsync(GetUserRequest req, CancellationToken ct)
    {
        var result = new GetUserResult
        {
            FullName = $"{req.FirstName} {req.LastName}",
            IsOver18 = req.Age > 18
        };
        
        await SendAsync(result, cancellation: ct);
    }
}

public class GetUserRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; }
}

public class GetUserResult
{
    public string? FullName { get; set; }
    public bool IsOver18 { get; set; }
}