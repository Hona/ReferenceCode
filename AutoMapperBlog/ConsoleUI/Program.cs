using System.Text.Json;
using App.Manual;
using AutoMapper;
using ConsoleUI;
using Domain;

var automapper = new MapperConfiguration(cfg => cfg.AddProfile<App.AutoMapper.Mapping>()).CreateMapper();

var weatherForecast = new WeatherForecast
{
    Date = new DateOnly(2021, 6, 1),
    TemperatureC = 38,
    Summary = "Hot"
};

var manualDto = weatherForecast.ToDto();
var mapperlyDto = App.Mapperly.Mapper.ToDto(weatherForecast);
var autoMapperDto = automapper.Map<App.AutoMapper.WeatherForecastDto>(weatherForecast);

Console.WriteLine("# Just Mapping");

Console.WriteLine("## Manual");
PrintObject(manualDto);

Console.WriteLine("## Mapperly");
PrintObject(mapperlyDto);

Console.WriteLine("## AutoMapper");
PrintObject(autoMapperDto);


var efSamples = new EfCoreSample();
Console.WriteLine();
Console.WriteLine("# EF Core Projections");
Console.WriteLine("## AutoMapper");
Console.WriteLine(efSamples.AutoMapperProjection());
Console.WriteLine("## Mapperly");
Console.WriteLine(efSamples.MapperlyProjection());

return;

void PrintObject(object toPrint) => Console.WriteLine(JsonSerializer.Serialize(toPrint) + Environment.NewLine);