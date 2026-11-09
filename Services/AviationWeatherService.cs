using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class AviationWeatherService : IAviationWeatherService
    {
        private static readonly HttpClient client = CreateClient();

        private static HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.ParseAdd("WpfWeatherDashboard/1.0");
            return client;
        }

        public async Task<AviationRoot?> GetAviationMetarAsync(string ids)
        {
            string symbol = Uri.EscapeDataString(ids.Trim().ToUpper());
            string url = $"https://aviationweather.gov/api/data/metar?ids={symbol}&format=json";

            var response = await client.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.NoContent) return null;

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Aviation request failed {response.StatusCode}");
            }

            var list = await response.Content.ReadFromJsonAsync<List<AviationRoot>>();

            return list?.FirstOrDefault();
        }

    }
}
