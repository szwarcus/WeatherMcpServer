namespace WeatherMcpServer.HttpClients.DelegatingHandlers
{
    public class GeocodeApiKeyDelegatingHandler : DelegatingHandler
    {
        private const string ApiKey = "YOUR_API_KEY";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var uriBuilder = new UriBuilder(request.RequestUri!);
            var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
            query["api_key"] = ApiKey;
            uriBuilder.Query = query.ToString();
            request.RequestUri = uriBuilder.Uri;
            return base.SendAsync(request, cancellationToken);
        }
    }
}
