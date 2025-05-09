using APIDevelopment.BasicController.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIDevelopment.BasicController.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastsController : ControllerBase
{
    [HttpPut("{id}")]
    public IActionResult UpdateWeatherForecast(int id, [FromBody] WeatherForecast weatherForecast)
    {
        if(id < 0 || id >= WeatherData.Count)
        {
            return NotFound();
        }
        WeatherData[id] = weatherForecast;
        return NoContent();
    }
    [HttpPost]
    public IActionResult CreateWeatherForecast([FromBody] WeatherForecast weatherForecast)
    {
        WeatherData.Add(weatherForecast);
        var id = WeatherData.Count - 1;
        return CreatedAtAction(nameof(GetWeatherForecastForId), new { id }, weatherForecast);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteWeatherForecast(int id)
    {
        if (id >= 0 && id < WeatherData.Count)
        {
            WeatherData.RemoveAt(id);
            return NoContent();
        }
        return NotFound();
    }

    [HttpGet(template: "by-day")]
    public IActionResult GetWeatherForecastAfterDay([FromQuery] int? day)
    {
        WeatherForecast[] weatherForecasts = [.. WeatherData];
        if (day == null)
        {
            return Ok(weatherForecasts);
        }
        if (day != null)
        {
            if (IsIndexInRange((int)day))
            {
                return Ok(weatherForecasts[(int)day]);
            }
        }
        return NotFound();
    }

    [HttpGet(template:"by-days")]
    public IActionResult GetWeatherForecastAfterDays([FromQuery] List<int>? days)
    {
        WeatherForecast[] weatherForecasts = [.. WeatherData];
        if (days == null)
        {
            return Ok(weatherForecasts);
        }
        if (days != null && days.Count > 0)
        {
            return Ok(days.Where(i => IsIndexInRange(i)).Select(index => weatherForecasts[index]));
        }
        return NotFound();
    }

    [HttpGet("{id}")]
    public IActionResult GetWeatherForecastForId(int id)
    {
        if (id < 0 || id >= WeatherData.Count)
        {
            return NotFound();
        }
        return Ok(WeatherData[id]);
    }

    private static readonly string[] Summaries =
                    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static List<WeatherForecast> WeatherData = Enumerable.Range(0, Summaries.Length).Select(index => new WeatherForecast
    {
        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index + 1)),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = Summaries[index],
    }).ToList();
    private static bool IsIndexInRange(int i) => i >= 0 && i < WeatherData.Count;
}