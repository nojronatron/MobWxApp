using MobWxUI.Models;

namespace MobWxUI.Helpers
{
    public interface IUserSettingsParams
    {
        ICoordinateModel Coordinates { get; set; }
        string CoordinatesFrom { get; set; }
        ForecastResponseModel CurrentForecast { get; set; }
        PointsResponseModel PointsResponse { get; set; }
        List<Period> ForecastPeriods { get; set; }

        bool HasCoordinates { get; }
        bool HasPointsResponse { get; }
        bool HasForecastResponse { get; }

        void AddCoordinates(string latitude, string longitude);
        void AddCoordinates(ICoordinateModel coordinates);
        void AddCoordinates(Location? location);

        void AddPointsResponse(PointsResponseModel pointsResponse);
        Task<bool> AddForecastResponseAsync(ForecastResponseModel forecastResponse);
    }
}