using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MauiBlazorApp.Data
{
    public class WeatherForecastService
    {
        private readonly HttpClient _httpClient;

        public WeatherForecastService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("WeatherApi");
        }


        public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            WeatherForecast[] weatherForecasts = await _httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
            return weatherForecasts;
        }
    }
}
