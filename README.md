# WeatherAPI

## Overview# WeatherAPI

## Overview

WeatherAPI is a RESTful web service built with ASP.NET Core (.NET 9) that provides weather information for various locations. The API is designed for easy integration with client applications and supports modern web development best practices.

## Features

- Retrieve current weather data for a given city or location
- Support for metric units
- Well-structured, versioned API endpoints
- Built-in OpenAPI/Swagger documentation
- Error handling and validation



   

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio 2022 or later (recommended)

### Building and Running

1. Clone the repository:
2. Restore dependencies:
   -**Configure tokens.json:**  
   The application requires a `tokens.json` file in the root directory for API keys and sensitive configuration.  
   sample: `tokens.sample.json`:
3. Build the project:
4. Run the API:
5. The API will be available at `https://localhost:5001` (or the port specified in launch settings).

### API Documentation

- Swagger UI is available at `/swagger` when running the application.


## Project Structure

- `Controllers/` - API controllers
- `ResponseModel/` - Response models for API endpoints
- `Services/` - Business logic and weather data providers
- `Interfaces/` - Interfaces for services`

## Contributing

Contributions are welcome! Please open issues or submit pull requests.

## License

This project is licensed under the MIT License.
