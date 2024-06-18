using MobWxUI.Models;

namespace MobWxUI.Helpers
{
    public interface IUserSettingsParams
    {
        ICoordinateModel Coordinates { get; set; }
        string CoordinatesFrom { get; set; }
        ForecastResponseModel CurrentForecast { get; set; }
        Period CurrentPeriodForecast { get; set; }
        List<Period> ForecastPeriods { get; set; }
        bool HasCoordinates { get; }
        bool HasForecastResponse { get; }
        bool HasPointsResponse { get; }
        PointsResponseModel PointsResponse { get; set; }

        void AddCoordinates(ICoordinateModel coordinates);
        void AddCoordinates(Location? location);
        void AddCoordinates(string latitude, string longitude);
        Task<bool> AddForecastResponseAsync(ForecastResponseModel forecastResponse);
        void AddPointsResponse(PointsResponseModel pointsResponse);
    }
}