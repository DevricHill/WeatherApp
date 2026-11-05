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
    public partial class WeatherViewModel : ObservableObject
    {
        private IWeatherService weatherService;

        public WeatherViewModel(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        [ObservableProperty]
        private string apiKey = "";

        [ObservableProperty]
        private string zipCode = "";

        [ObservableProperty]
        private string locationName = "Weather";

        [ObservableProperty]
        private string statusText = "Enter a zip code and press Submit.";

        public ObservableCollection<WeatherProperty> WeatherValues { get; } = new();

        [RelayCommand]
        private async Task LoadWeatherAsync()
        {
            if (string.IsNullOrWhiteSpace(ZipCode) || string.IsNullOrWhiteSpace(ApiKey))
            {
                StatusText = "Please enter both an API key and a zip code.";
                return;
            }

            StatusText = "Loading...";

            try
            {
                Root? weather = await weatherService.GetRealTimeWeatherAsync(ZipCode, ApiKey);

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

                LocationName = weather.location?.name ?? ZipCode;
                StatusText = $"Updated: {weather.data.time.ToLocalTime():h:mm tt}";
            }
            catch (Exception ex)
            {
                StatusText = $"Something went wrong: {ex.Message}";
            }
        }

    }
}
