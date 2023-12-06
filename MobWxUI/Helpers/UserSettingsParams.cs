using MobWxUI.Models;

namespace MobWxUI.Helpers
{
    public class UserSettingsParams : IUserSettingsParams
    {
        public ICoordinateModel Coordinates { get; set; } = new CoordinateModel();
        public string CoordinatesFrom { get; set; }
        public PointsResponseModel PointsResponse { get; set; }
        public ForecastResponseModel CurrentForecast { get; set; }

        public bool HasCoordinates => !Coordinates.IsEmpty;
        public bool HasPointsResponse => PointsResponse.Cwa != null;
        public bool HasForecastResponse => !string.IsNullOrWhiteSpace(CurrentForecast.Updated);

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

        public void AddCoordinates(Location? location)
        {
            Coordinates.SetCoordinates(location);
        }

        public void AddCoordinates(ICoordinateModel coordinates)
        {
            Coordinates = coordinates;
        }
    }
}
