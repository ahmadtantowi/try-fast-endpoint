global using FastEndpoints;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TryFastEndpoint;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();

var app = builder.Build();
app.UseAuthorization();
app.UseFastEndpoints();

app.Run();
