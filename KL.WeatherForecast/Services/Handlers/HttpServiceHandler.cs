using Newtonsoft.Json;

namespace KL.WeatherForecast.Api.Services.Handlers
{
    public class HttpServiceHandler : IHttpService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        public HttpServiceHandler(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            this._configuration = configuration;
            this._httpClient = httpClientFactory.CreateClient(nameof(HttpClient));
        }
        public async Task<T> GetAsync<T>(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("user-agent", _configuration.GetSection("ApplicationName").Value);

            var response = await this._httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            else
            {
                throw new Exception("An error has occured");
            }

        }
    }
}
