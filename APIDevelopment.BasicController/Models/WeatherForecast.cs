using System.Text.Json.Serialization;

namespace APIDevelopment.BasicController.Models;

public class WeatherForecast
{
    public required DateOnly Date { get; set; }

    public required int TemperatureC { get; set; }
    [JsonIgnore]
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public required string Summary { get; set; }
}
