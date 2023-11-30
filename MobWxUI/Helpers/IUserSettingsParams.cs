using MobWxUI.Models;

namespace MobWxUI.Helpers
{
    public interface IUserSettingsParams
    {
        ICoordinateModel Coordinates { get; set; }
        string CoordinatesFrom { get; set; }
        ForecastResponseModel CurrentForecast { get; set; }
        PointsResponseModel PointsResponse { get; set; }

        void AddCoordinates(string latitude, string longitude);
    }
}