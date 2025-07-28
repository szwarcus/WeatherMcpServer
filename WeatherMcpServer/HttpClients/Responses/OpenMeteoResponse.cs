using System.Text.Json.Serialization;
using WeatherMcpServer.HttpClients.Responses.Parts;

namespace WeatherMcpServer.HttpClients.Responses
{
    public record OpenMeteoResponse([property: JsonPropertyName("latitude")] double Latitude, [property: JsonPropertyName("longitude")] double Longitude, [property: JsonPropertyName("generationtime_ms")] double GenerationTimeMs, [property: JsonPropertyName("utc_offset_seconds")] int UtcOffsetSeconds, [property: JsonPropertyName("elevation")] double Elevation, [property: JsonPropertyName("current_units")] CurrentUnits? CurrentUnits, [property: JsonPropertyName("current")] CurrentWeather? Current)
    {
        [JsonPropertyName("timezone")]
        public string Timezone { get; set; } = string.Empty;

        [JsonPropertyName("timezone_abbreviation")]
        public string TimezoneAbbreviation { get; set; } = string.Empty;
    }
}
