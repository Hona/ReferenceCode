using App.Mapperly;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Microsoft.EntityFrameworkCore;
using Riok.Mapperly.Abstractions;

namespace ConsoleUI;

public class WeatherForecastContext : DbContext
{
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("WeatherForecast");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WeatherForecast>().HasKey(e => e.Date);
    }
}

[Mapper]
public static partial class WeatherProjectionMapper
{
    public static partial IQueryable<EfCoreSample.WeatherProjection> Project(this IQueryable<WeatherForecast> q);
}

public class EfCoreSample : IDisposable, IAsyncDisposable
{
    private readonly WeatherForecastContext _context = new();
    private readonly IConfigurationProvider _automapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<WeatherForecast, WeatherProjection>());
    
    public EfCoreSample()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();

        var entity = new WeatherForecast
        {
            Date = new DateOnly(2021, 1, 1),
            TemperatureC = 25,
            Summary = "Warm"
        };

        _context.Add(entity);
        _context.SaveChanges();
    }

    public record WeatherProjection(DateOnly Date, int TemperatureC);
    
    
    public string AutoMapperProjection()
    {
        var output = _context.WeatherForecasts
            .AsQueryable()
            .ProjectTo<WeatherProjection>(_automapperConfig)
            .First();

        return output.ToString();
    }

    public string MapperlyProjection()
    {
        var output = _context.WeatherForecasts
            .AsQueryable()
            .Project()
            .First();
        
        return output.ToString();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }
}