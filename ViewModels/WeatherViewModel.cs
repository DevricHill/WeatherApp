using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    public partial class WeatherViewModel : BasicViewModel
    {
        private IWeatherService weatherService;

        public WeatherViewModel(IWeatherService weatherService)
        {
            this.weatherService = weatherService;

            StatusText = "Enter a zip code and press Submit.";
        }

        [ObservableProperty]
        private string apiKey = "";

        public ObservableCollection<WeatherProperty> WeatherValues { get; } = new();

        [RelayCommand]
        private async Task LoadWeatherAsync()
        {
            if (string.IsNullOrWhiteSpace(Id) || string.IsNullOrWhiteSpace(ApiKey))
            {
                StatusText = "Please enter both an API key and a zip code.";
                return;
            }

            StatusText = "Loading...";

            try
            {
                WeatherRoot? weather = await weatherService.GetRealTimeWeatherAsync(Id, ApiKey);

                if (weather?.data?.values is null)
                {
                    StatusText = "No weather data returned.";
                    return;
                }

                WeatherValues.Clear();
                var values = weather.data.values;

                foreach (var property in values.GetType().GetProperties())
                {
                    WeatherValues.Add(new WeatherProperty
                    {
                        Name = property.Name,
                        Value = property.GetValue(values)
                    });
                }

                LocationName = weather.location?.name ?? Id;
                StatusText = $"Updated: {weather.data.time.ToLocalTime():h:mm tt}";
            }
            catch (Exception ex)
            {
                StatusText = $"Something went wrong: {ex.Message}";
            }
        }

    }
}
