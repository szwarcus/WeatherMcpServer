using System.Text.Json.Serialization;

namespace WeatherMcpServer.HttpClients.Responses
{
    public class GeocodeResponse
    {
        [JsonPropertyName("lat")]
        public string Latitude { get; set; }

        [JsonPropertyName("lon")]
        public string Longitude { get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        [JsonPropertyName("importance")]
        public double Importance { get; set; }
    }
}
