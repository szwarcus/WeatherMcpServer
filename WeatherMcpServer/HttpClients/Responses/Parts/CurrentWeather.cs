using System.Text.Json.Serialization;

namespace WeatherMcpServer.HttpClients.Responses.Parts
{
    public class CurrentWeather
    {
        [JsonPropertyName("time")]
        public string Time { get; set; } = string.Empty;

        [JsonPropertyName("interval")]
        public int? Interval { get; set; }

        [JsonPropertyName("temperature_2m")]
        public double? Temperature2m { get; set; }

        [JsonPropertyName("wind_speed_10m")]
        public double? WindSpeed10m { get; set; }

        [JsonPropertyName("weather_code")]
        public double? WeatherCode { get; set; }
    }
}