using Refit;
using WeatherMcpServer.HttpClients.Responses;

namespace WeatherMcpServer.HttpClients
{
    public interface IGeocodeApi
    {
        [Get("/search")]
        Task<GeocodeResponse[]> GetGeocodeAsync([AliasAs("q")] string queryParam);
    }
}
