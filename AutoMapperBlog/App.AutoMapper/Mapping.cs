using AutoMapper;
using Domain;

namespace App.AutoMapper;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<WeatherForecast, WeatherForecastDto>();
    }
}
