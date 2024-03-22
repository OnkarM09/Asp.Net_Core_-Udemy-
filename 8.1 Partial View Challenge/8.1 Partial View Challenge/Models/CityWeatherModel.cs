namespace _8._1_Partial_View_Challenge.Models;

public class CityWeatherModel
{
    public string? CityUniqueCode { get; set; } = "";
    public string? CityName { get; set; } = "";
    public DateTime DateAndTime { get; set; }
    public int TemperatureFahrenheit { get; set; } = 0;
}
