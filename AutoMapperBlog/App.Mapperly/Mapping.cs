using Domain;
using Riok.Mapperly.Abstractions;

namespace App.Mapperly;

[Mapper]
public static partial class Mapper
{
    public static partial WeatherForecastDto ToDto(WeatherForecast entity);
    
    public static partial IQueryable<WeatherForecastDto> ProjectToDto(this IQueryable<WeatherForecast> q);
}