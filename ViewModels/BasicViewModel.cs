using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.ViewModels
{
    public partial class BasicViewModel : ObservableObject
    {
        [ObservableProperty]
        private string statusText = string.Empty;

        [ObservableProperty]
        private string id = string.Empty;

        [ObservableProperty]
        private string locationName = string.Empty;
    }
}
