namespace Domain;

// https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/WebApi-CSharp/WeatherForecast.cs
// Copied WeatherForecast from ASP.NET Core Web API template
// However, dropped the TemperatureF property as it is view-specific

public class WeatherForecast
{
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }
}