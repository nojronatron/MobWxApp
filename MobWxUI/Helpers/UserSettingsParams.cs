using MobWxUI.Models;
using System.Diagnostics;

namespace MobWxUI.Helpers
{
    public class UserSettingsParams : IUserSettingsParams
    {
        private readonly IApiHelper _apiHelper;
        public ICoordinateModel Coordinates { get; set; } = new CoordinateModel();
        public string CoordinatesFrom { get; set; }
        public PointsResponseModel PointsResponse { get; set; }
        public ForecastResponseModel CurrentForecast { get; set; }
        public List<Period> ForecastPeriods { get; set; }

        public bool HasCoordinates => !Coordinates.IsEmpty;
        public bool HasPointsResponse => PointsResponse.Cwa != null;
        public bool HasForecastResponse => !string.IsNullOrWhiteSpace(CurrentForecast.Updated);

        public UserSettingsParams(IApiHelper apiHelper)
        {
            CoordinatesFrom = "n/a";
            PointsResponse = new PointsResponseModel();
            CurrentForecast = new ForecastResponseModel();
            ForecastPeriods = new List<Period>();
            _apiHelper = apiHelper;
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

        public async Task<bool> AddForecastResponseAsync(ForecastResponseModel forecastResponse)
        {
            if (forecastResponse is null)
            {
                Debug.WriteLine($"AddForecastResponse: forecastResponse is null.");
                return false;
            }
            else
            {
                CurrentForecast = forecastResponse;

                if (forecastResponse.Periods.Length > 0)
                {
                    ForecastPeriods = new List<Period>(forecastResponse.Periods);
                    await GetWxPeriodIconAsync(ForecastPeriods);
                }
                else
                {
                    Debug.WriteLine($"AddForecastResponse: There are no Forecast Periods in the respose.");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Retrieves the weather images for each forecast period.
        /// </summary>
        /// <param name="forecastPeriods">The list of forecast periods.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task GetWxPeriodIconAsync(List<Period> forecastPeriods)
        {
            foreach (var period in forecastPeriods)
            {
                CancellationTokenSource token = new CancellationTokenSource();
                period.WxImageByteArray = await _apiHelper.GetWeatherIconEnhancedAsync(period.Icon, token.Token);
            }
        }
    }
}
