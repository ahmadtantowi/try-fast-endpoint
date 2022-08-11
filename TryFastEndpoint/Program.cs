global using FastEndpoints;
global using FastEndpoints.Security;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TryFastEndpoint;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();
builder.Services.AddAuthenticationJWTBearer(Constant.SigningKey);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(PolicyConstant.CustomerPolicy, x => x
        .RequireRole(RoleConstant.Customer)
        .RequireClaim(ClaimConstant.UserId));
});

var app = builder.Build();
app.UseDefaultExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();

app.Run();
