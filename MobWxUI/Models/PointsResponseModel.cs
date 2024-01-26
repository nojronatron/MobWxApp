namespace MobWxUI.Models
{
    public class PointsResponseModel : IPointsResponseModel
    {
        public string? Id { get; set; }
        public string? Type { get; set; }
        public string? Geometry { get; set; }
        public string? Cwa { get; set; } //  e.g. "SEW"
        public string? ForecastOffice { get; set; } // this is an API url
        public string? GridId { get; set; } // e.g. "SEW"
        public int? GridX { get; set; }
        public int? GridY { get; set; }
        public string? Forecast { get; set; } // API url
        public string? ForecastHourly { get; set; }  // API url
        public string? ObservationStations { get; set; } //  API url
        public RelativeLocation RelativeLocation { get; set; } = new();
        public string? ForecastZone { get; set; }    // API url
        public string? County { get; set; }  //  API url
        public string? FireWeatherZone { get; set; } //  API url
        public string? TimeZone { get; set; }    //  plain-text timezone e.g. "America/Los_Angeles"
        public string? RadarStation { get; set; }    //  e.g. "KATX"
    }
}
