using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherService : IWeatherService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<Root?> GetRealTimeWeatherAsync(string zipCode, string apiKey)
        {
            string location = Uri.EscapeDataString(zipCode);
            string url = $"https://api.tomorrow.io/v4/weather/realtime?location={location}&units=imperial&apikey={apiKey}";

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Weather request failed {response.StatusCode}");
            }

            return await response.Content.ReadFromJsonAsync<Root>();
        }
    }
}
