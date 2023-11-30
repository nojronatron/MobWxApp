namespace MobWxUI.Models
{
    public class ForecastResponseModel : IForecastResponseModel
    {
        public string? Updated { get; set; }
        public string? Units { get; set; }
        public string? ForecastGenerator { get; set; }
        public DateTimeOffset? GeneratedAt { get; set; }
        public DateTimeOffset? UpdatedTime { get; set; }
        public string? ValidTimes { get; set; }
        public Elevation? Elevation { get; set; }
        public Period[] Periods { get; set; } = new Period[14];
    }
}
