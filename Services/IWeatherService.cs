using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IWeatherService
    {
        Task<Root> GetRealTimeWeatherAsync(string zip, string apiKey);
    }
}
