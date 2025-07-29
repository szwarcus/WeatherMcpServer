using System.Text.Json.Serialization;

namespace WeatherMcpServer.HttpClients.Responses
{
    public record GeocodeResponse([property: JsonPropertyName("lat")] string Latitude, [property: JsonPropertyName("lon")] string Longitude, [property: JsonPropertyName("display_name")] string DisplayName, [property: JsonPropertyName("importance")] double Importance);
}
