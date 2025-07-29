using System.ComponentModel;
using ModelContextProtocol.Server;
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


        [McpServerTool(Name = "GetCityWeather")]
        [Description("Get current weather for a city in specified country.")]
        public async Task<string> GetCityWeather(
            [Description("The name of the city. Additionally a voivodeship name can be added (e.g. Toruń, Kuyavian-Pomeranian, Brasschaat).")] string? city,
            [Description("The name of the country. It can be also defined as country code like PL or BE")] string? country)
        {
            // just for debug purposes
            //Debugger.Launch(); 

            if (string.IsNullOrWhiteSpace(city))
            {
                return "City name has to be provided to correctly provide weather.";
            }

            if (string.IsNullOrWhiteSpace(country))
            {
                return "Country name or code has to be provided to correctly provide weather.";
            }

            var geocode = await _geocodeApi.GetGeocodeAsync($"{city}, {country}");

            if (geocode == null || !geocode.Any())
            {
                return $"Did not found such {city} in {country}.";
            }

            var bestMatch = geocode.OrderByDescending(p => p.Importance).First();

            var response = await _openMeteoApi.GetCurrentWeatherAsync(
                latitude: bestMatch.Latitude,
                longitude: bestMatch.Longitude,
                current: "temperature_2m,wind_speed_10m,weather_code"
            );

            return $"""
                    City: {bestMatch.DisplayName}
                    Latitude: {bestMatch.Latitude}, Longitude: {bestMatch.Longitude}
                    Current time: {response.Current?.Time}
                    Timezone: {response.Timezone}
                    Temperature (2m) [{response.CurrentUnits.Temperature2m}]: {response.Current.Temperature2m}
                    Wind speed (10m) [{response.CurrentUnits.WindSpeed10m}]: {response.Current.WindSpeed10m} 
                    Weather code: [{response.Current.WeatherCode}]
                    """;
        }
    }
}
