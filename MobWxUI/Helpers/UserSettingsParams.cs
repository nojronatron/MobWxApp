using MobWxUI.Models;
using System.Diagnostics;

namespace MobWxUI.Helpers
{
    public class UserSettingsParams : IUserSettingsParams
    {
        public ICoordinateModel Coordinates { get; set; } = new CoordinateModel();
        public string CoordinatesFrom { get; set; }
        public PointsResponseModel PointsResponse { get; set; }
        public ForecastResponseModel CurrentForecast { get; set; }
        public List<Period> ForecastPeriods { get; set; }

        public bool HasCoordinates => !Coordinates.IsEmpty;
        public bool HasPointsResponse => PointsResponse.Cwa != null;
        public bool HasForecastResponse => !string.IsNullOrWhiteSpace(CurrentForecast.Updated);

        public UserSettingsParams()
        {
            CoordinatesFrom = "n/a";
            PointsResponse = new PointsResponseModel();
            CurrentForecast = new ForecastResponseModel();
            ForecastPeriods = new List<Period>();
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

        public void AddPointsResponse(PointsResponseModel pointsResponse)
        {
            PointsResponse = pointsResponse;
        }

        public bool AddForecastResponse(ForecastResponseModel forecastResponse)
        {
            if (forecastResponse is null)
            {
                Debug.WriteLine($"AddForecastResponse: forecastResponse is null.");
                return false;
            }
            else
            {
                CurrentForecast = forecastResponse;

                if (forecastResponse.Periods.Count() > 0)
                {
                    ForecastPeriods = new List<Period>(forecastResponse.Periods);
                }
                else
                {
                    Debug.WriteLine($"AddForecastResponse: forecastResponse.Periods.Count() is 0.");
                    return false;
                }
            }

            return true;
        }
    }
}
