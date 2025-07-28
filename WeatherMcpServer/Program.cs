using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;
using WeatherMcpServer.HttpClients;
using WeatherMcpServer.HttpClients.DelegatingHandlers;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddTransient<GeocodeApiKeyDelegatingHandler>();

builder.Services.AddRefitClient<IOpenMeteoApi>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri("https://api.open-meteo.com");
    });

builder.Services.AddRefitClient<IGeocodeApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://geocode.maps.co"))
    .AddHttpMessageHandler<GeocodeApiKeyDelegatingHandler>();

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

var app = builder.Build();

await app.RunAsync();