using MobWxUI.Models;

namespace MobWxUI.Helpers
{
    public class UserSettingsParams : IUserSettingsParams
    {
        public ICoordinateModel Coordinates { get; set; } = new CoordinateModel();
        public string CoordinatesFrom { get; set; }
        public PointsResponseModel PointsResponse { get; set; }
        public ForecastResponseModel CurrentForecast { get; set; }

        public UserSettingsParams()
        {
            CoordinatesFrom = "n/a";
            PointsResponse = new PointsResponseModel();
            CurrentForecast = new ForecastResponseModel();
        }

        public void AddCoordinates(string latitude, string longitude)
        {
            Coordinates.SetLatitude(latitude);
            Coordinates.SetLongitude(longitude);
        }
    }
}
