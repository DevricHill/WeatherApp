using Microsoft.Web.WebView2.Wpf;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;
using WeatherApp.Models;
using WeatherApp.ViewModels;
using WeatherApp.Services;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            weatherTab.DataContext = new WeatherViewModel(new WeatherService());
            aviationTab.DataContext = new AviationViewModel(new AviationWeatherService());
        }

      
            
            
        
    }
}