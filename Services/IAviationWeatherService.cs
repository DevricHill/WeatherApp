using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IAviationWeatherService
    {
        Task<AviationRoot?> GetAviationMetarAsync(string ids);
    }
}
