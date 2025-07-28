using System.Text.Json.Serialization;

namespace WeatherMcpServer.HttpClients.Responses.Parts
{
    public class CurrentUnits
    {
        [JsonPropertyName("time")]
        public string Time { get; set; } = string.Empty;

        [JsonPropertyName("interval")]
        public string? Interval { get; set; }

        [JsonPropertyName("temperature_2m")]
        public string? Temperature2m { get; set; }

        [JsonPropertyName("wind_speed_10m")]
        public string? WindSpeed10m { get; set; }
    }
}
