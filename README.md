# WeatherApp

A Windows desktop app for checking aviation weather. Shows live METAR reports, current conditions by location, and sectional charts in one window.

## Features
- METAR reports — type an airport code like KSFO for the latest observation. No API key needed.
- Current weather — temperature, wind, humidity and more. Look up by US ZIP code or by latitude and longitude. Requires a free Tomorrow.io API key.
-Sectional charts — shown in a panel beside the data.

## Built with

C# · .NET 10 · WPF · CommunityToolkit.Mvvm · WebView2

APIs: Tomorrow.io for weather, Aviation Weather Center for METAR.

### Running it
1. Open WeatherApp.slnx in Visual Studio 2026 on Windows and press F5.
2. Aviation tab — enter an airport code like KSFO. Works immediately, no setup.
3. Weather tab — you need a Tomorrow.io API key for this tab. Sign up free at tomorrow.io/weather-api, then paste the key into the app along with a location and press Submit. Without a key this tab will not return data.

Locations accept either format:
```
30303                ZIP code
33.7582, -84.3971    latitude, longitude
```
## What's next
- Save the API key instead of typing it each time
- Register the services in a DI container
- Unit tests for the service layer
- Multi-day forecast
