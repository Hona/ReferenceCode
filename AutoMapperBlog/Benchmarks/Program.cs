using App.Manual;
using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Domain;

BenchmarkRunner.Run<Benchmarks>();

public class Benchmarks
{
    private static readonly WeatherForecast DomainEntity = new WeatherForecast
    {
        Date = new DateOnly(2021, 1, 1),
        TemperatureC = 25,
        Summary = "Mild"
    };
    
    [Benchmark(Baseline = true)]
    public int Manual()
    {
        var dto = DomainEntity.ToDto();

        return dto.TemperatureF;
    }
    
    private static readonly IMapper Mapper = new MapperConfiguration(cfg => cfg.AddProfile<App.AutoMapper.Mapping>()).CreateMapper();
    
    [Benchmark]
    public int AutoMapper()
    {
        var dto = Mapper.Map<App.AutoMapper.WeatherForecastDto>(DomainEntity);

        return dto.TemperatureF;
    }
    
    [Benchmark]
    public int Mapperly()
    {
        var dto = App.Mapperly.Mapper.ToDto(DomainEntity);

        return dto.TemperatureF;
    }
}