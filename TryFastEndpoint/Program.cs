global using FastEndpoints;
global using FastEndpoints.Security;

using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TryFastEndpoint;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints(options => options.SourceGeneratorDiscoveredTypes = DiscoveredTypes.All);
builder.Services.AddAuthenticationJWTBearer(Constant.SigningKey);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(PolicyConstant.CustomerPolicy, x => x
        .RequireRole(RoleConstant.Customer)
        .RequireClaim(ClaimConstant.UserId));
});
builder.Services.AddSwaggerDoc();

var app = builder.Build();
app.UseDefaultExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3(settings => settings.ConfigureDefaults());

app.Run();
