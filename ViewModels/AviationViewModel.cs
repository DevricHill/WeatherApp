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
    public partial class AviationViewModel : ObservableObject
    {
        private IAviationWeatherService aviationWeatherService;

        public AviationViewModel(IAviationWeatherService aviationWeather)
        {
            aviationWeatherService = aviationWeather;
        }

        [ObservableProperty]
        private string ids = "";

        [ObservableProperty]
        private string statusText = "Enter a METAR ID and press Submit.";
        [ObservableProperty]
        private string locationName = "Aviation";

        public ObservableCollection<AviationProperty> AviationValues { get; } = new();

        [RelayCommand]
        private async Task LoadAviationAsync()
        {
            if (string.IsNullOrEmpty(ids))
            {
                StatusText = "Please enter a valid METAR ID.";
                return;
            }

            StatusText = "Loading...";

            try
            {
                AviationRoot? aviation = await aviationWeatherService.GetAviationMetarAsync(ids);

                if(aviation is null)
                {
                    StatusText = "No data returned";
                    return;
                }

                AviationValues.Clear();
                var values = aviation;

                foreach (var property in values.GetType().GetProperties())
                {
                   object? propertyValue = property.GetValue(aviation);

                    if(property.Name.Equals("clouds", StringComparison.OrdinalIgnoreCase))
                    {
                        if(propertyValue is System.Collections.IEnumerable list)
                        {
                            var cloudItems = list.Cast<object>().Select(item => item.ToString()).ToList();

                            propertyValue = cloudItems.Any() ? string.Join(", ", cloudItems) : "Clear";
                        }
                    }

                    AviationValues.Add(new AviationProperty
                    {
                        Name = property.Name,
                        Value = propertyValue
                    });
                }
                LocationName = aviation.name;

                StatusText = $"Updated: {DateTime.Now: h:mm tt}";

            }
            catch(Exception ex) 
            {
                StatusText = $"Something went wrong {ex.Message}";
            }


        }



    }
}
