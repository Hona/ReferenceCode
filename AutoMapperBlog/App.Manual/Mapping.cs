using Domain;

namespace App.Manual;

public static class Mapping
{
    public static WeatherForecastDto ToDto(this WeatherForecast entity)
    {
        return new WeatherForecastDto
        {
            Date = entity.Date,
            TemperatureC = entity.TemperatureC,
            Summary = entity.Summary
        };
    }
}