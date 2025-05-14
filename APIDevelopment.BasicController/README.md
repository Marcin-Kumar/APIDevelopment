# ASP.NET Core Web API Development

This project is a simple ASP.NET Core Web API designed to explore and experiment with Web API development using .NET 9. It includes a `WeatherForecastsController` that provides CRUD operations and query capabilities for weather forecast data.

## Features

- **CRUD Operations**:
  - Create, Read, Update, and Delete weather forecasts.
- **Query Support**:
  - Fetch forecasts by specific days or a range of days.
- **In-Memory Data**:
  - Weather data is stored in-memory for simplicity.

## Endpoints

### WeatherForecastsController

| HTTP Method | Endpoint                  | Description                                      |
|-------------|---------------------------|--------------------------------------------------|
| `GET`       | `/api/weatherforecasts`   | Get all weather forecasts.                      |
| `GET`       | `/api/weatherforecasts/{id}` | Get a specific weather forecast by ID.          |
| `GET`       | `/api/weatherforecasts/by-day?day={day}` | Get a forecast for a specific day.              |
| `GET`       | `/api/weatherforecasts/by-days?days={days}` | Get forecasts for multiple days.                |
| `POST`      | `/api/weatherforecasts`   | Create a new weather forecast.                  |
| `PUT`       | `/api/weatherforecasts/{id}` | Update an existing weather forecast by ID.      |
| `DELETE`    | `/api/weatherforecasts/{id}` | Delete a weather forecast by ID.                |

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

### Running the Project

1. Clone the repository:
   
```shell
   git clone <repository-url>
   cd APIDevelopment.BasicController
   
```

2. Restore dependencies:
   
```shell
   dotnet restore
   
```

3. Run the application:
   
```shell
   dotnet run
   
```

4. The API will be available at `https://localhost:{port}/api/weatherforecasts`.

### Testing the API

You can test the API using in-built Scalar UI

## Project Structure

- **Controllers**: Contains the `WeatherForecastsController` for handling API requests.
- **Models**: Includes the `WeatherForecast` model representing the weather data.
- **Properties**: Configuration files like `launchSettings.json`.

## Example Data

The API generates sample weather data with random temperatures and summaries like "Freezing", "Warm", or "Hot".
