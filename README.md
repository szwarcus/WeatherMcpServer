# WeatherMcpServer

A .NET 9 server application that integrates with the Open-Meteo weather API and the Maps.co Geocode API. It demonstrates how to fetch current weather data and geocode information using Refit and dependency injection.

## Features
- Fetches current weather (temperature, wind speed) for a given location using Open-Meteo API
- Retrieves geocode information (latitude, longitude, display name, importance) for a place using Maps.co Geocode API
- Uses Refit for type-safe HTTP API calls
- API key for geocode requests is injected via a delegating handler

## Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio 2022 or later (recommended)
- Internet connection for API calls
- A valid API key for [Maps.co Geocode API](https://geocode.maps.co/)

## Getting Started
1. Clone the repository:git clone https://github.com/yourusername/WeatherMcpServer.git2. Open the solution in Visual Studio.
3. Restore NuGet packages.
4. **Set your Geocode API key:**
   - Open `WeatherMcpServer/HttpClients/DelegatingHandlers/GeocodeApiKeyDelegatingHandler.cs`
   - Replace `YOUR_API_KEY` with your actual API key: ```csharp
 private const string ApiKey = "YOUR_API_KEY";
 ```5. Build and run the project.

## Usage
- The application will fetch and display current weather and geocode information for sample locations on startup.
- You can modify the test calls in `Program.cs` to use different locations or integrate the APIs into your own tools/services.

## Notes
- The Geocode API key is required for geocode requests. Without it, those requests will fail.
- Weather data is fetched from [Open-Meteo](https://open-meteo.com/).

## License
This project is for demonstration purposes. Please check the respective API providers for their terms of use.