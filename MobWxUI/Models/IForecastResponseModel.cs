
namespace MobWxUI.Models
{
    public interface IForecastResponseModel
    {
        Elevation? Elevation { get; set; }
        string? ForecastGenerator { get; set; }
        DateTimeOffset? GeneratedAt { get; set; }
        Period[] Periods { get; set; }
        string? Units { get; set; }
        string? Updated { get; set; }
        DateTimeOffset? UpdatedTime { get; set; }
        string? ValidTimes { get; set; }
    }
}