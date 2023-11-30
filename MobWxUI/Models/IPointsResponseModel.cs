namespace MobWxUI.Models
{
    public interface IPointsResponseModel
    {
        string? County { get; set; }
        string? Cwa { get; set; }
        string? FireWeatherZone { get; set; }
        string? Forecast { get; set; }
        string? ForecastHourly { get; set; }
        string? ForecastOffice { get; set; }
        string? ForecastZone { get; set; }
        string? Geometry { get; set; }
        string? GridId { get; set; }
        int? GridX { get; set; }
        int? GridY { get; set; }
        string? Id { get; set; }
        string? ObservationStations { get; set; }
        string? RadarStation { get; set; }
        RelativeLocation? RelativeLocation { get; set; }
        string? TimeZone { get; set; }
        string? Type { get; set; }
    }
}