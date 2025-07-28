using ModelContextProtocol.Server;
using System.ComponentModel;
using WeatherMcpServer.HttpClients;

namespace WeatherMcpServer.Tools
{
    [McpServerToolType]
    public sealed class WeatherTools
    {
        private readonly IOpenMeteoApi _openMeteoApi;
        private readonly IGeocodeApi _geocodeApi;

        public WeatherTools(IOpenMeteoApi openMeteoApi, IGeocodeApi geocodeApi)
        {
            _openMeteoApi = openMeteoApi;
            _geocodeApi = geocodeApi;
        }


        [McpServerTool(Name = "GetPolandCityWeather")]
        [Description("Get weather for a city in Poland.")]
        public async Task<string> GetCityWeather([Description("The name of the city in Poland. Additionally a voivodeship name can be added (e.g. Toruń, Kuyavian-Pomeranian).")] string city)
        {
            // just for debug purposes
            //Debugger.Launch(); 
            var geocode = await _geocodeApi.GetGeocodeAsync($"{city}, Poland");

            if (geocode == null || !geocode.Any())
            {
                return $"Did not found such {city} in Poland.";
            }

            var bestMatch = geocode.OrderByDescending(p => p.Importance).First();

            var response = await _openMeteoApi.GetCurrentWeatherAsync(
                latitude: bestMatch.Latitude,
                longitude: bestMatch.Longitude,
                current: "temperature_2m,wind_speed_10m"
            );

            return $"""
                    City: {bestMatch.DisplayName}
                    Latitude: {bestMatch.Latitude}, Longitude: {bestMatch.Longitude}
                    Current time: {response.Current?.Time}
                    Timezone: {response.Timezone}
                    Temperature (2m) [{response.CurrentUnits.Temperature2m}]: {response.Current.Temperature2m}
                    Wind speed (10m) [{response.CurrentUnits.WindSpeed10m}]: {response.Current.WindSpeed10m} 
                    """;
        }
    }
}
