using Refit;
using WeatherMcpServer.HttpClients.Responses;

namespace WeatherMcpServer.HttpClients
{
    public interface IOpenMeteoApi
    {
        [Get("/v1/forecast")]
        Task<OpenMeteoResponse> GetCurrentWeatherAsync(string latitude,
            string longitude,
            string current);
    }
}
