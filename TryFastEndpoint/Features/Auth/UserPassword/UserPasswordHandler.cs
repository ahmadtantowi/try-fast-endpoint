namespace TryFastEndpoint.Features.Auth.UserPassword;

public class UserPasswordHandler : Endpoint<UserPasswordRequest>
{
    public override void Configure()
    {
        Post("/auth/up");
        AllowAnonymous();

        Summary(sum => sum.Summary = "Login with Username & Password");
    }

    public override async Task HandleAsync(UserPasswordRequest req, CancellationToken ct)
    {
        var jwtToken = JWTBearer.CreateToken(
            signingKey: Constant.SigningKey,
            expireAt: DateTime.Now.AddDays(31),
            permissions: new[] { "ReadUser", "ManageUser" },
            roles: new[] { RoleConstant.Customer },
            claims: new[] { (ClaimConstant.UserId, "abc123") }
        );

        await SendAsync(jwtToken, cancellation: ct);
    }
}

public class UserPasswordRequest
{
    public string? Username { get; set; }
    public string? Password { get; set; }
}
