using System.Net.Http.Json;
using System.Text.Json;
using TPos.Ordering;

namespace TryCode.Client
{
    public class WeatherClient
    {
        private readonly JsonSerializerOptions options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        private readonly HttpClient client;

        public WeatherClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task<OrderGetListDto[]> GetWeatherAsync()
        {
            return await this.client.GetFromJsonAsync<OrderGetListDto[]>("/weatherforecast");
        }
    }
}
