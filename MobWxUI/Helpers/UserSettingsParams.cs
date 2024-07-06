using MobWxUI.Models;
using System.Diagnostics;

namespace MobWxUI.Helpers
{
    public class UserSettingsParams : IUserSettingsParams
    {
        private readonly IApiHelper _apiHelper;
        public ICoordinateModel Coordinates { get; set; } = new CoordinateModel();
        public string CoordinatesFrom { get; set; } = string.Empty;
        public PointsResponseModel PointsResponse { get; set; } = new PointsResponseModel();
        public ForecastResponseModel CurrentForecast { get; set; } = new ForecastResponseModel();
        public List<Period> ForecastPeriods { get; set; } = new List<Period>();
        public Period CurrentPeriodForecast { get; set; } = new Period();

        public bool HasCoordinates => !Coordinates.IsEmpty;
        public bool HasPointsResponse => PointsResponse.Cwa != null;
        public bool HasForecastResponse => !string.IsNullOrWhiteSpace(CurrentForecast.Updated);

        // CTOR
        public UserSettingsParams(IApiHelper apiHelper)
        {
            CoordinatesFrom = "n/a";
            _apiHelper = apiHelper;
        }

        /// <summary>
        /// Adds the coordinates using the latitude and longitude values.
        /// </summary>
        /// <param name="latitude">The latitude value.</param>
        /// <param name="longitude">The longitude value.</param>
        public void AddCoordinates(string latitude, string longitude)
        {
            Coordinates.SetLatitude(latitude);
            Coordinates.SetLongitude(longitude);
        }

        /// <summary>
        /// Adds the coordinates using the latitude and longitude values.
        /// </summary>
        /// <param name="location">The location object containing the latitude and longitude values.</param>
        public void AddCoordinates(Location? location)
        {
            Coordinates.SetCoordinates(location);
        }

        /// <summary>
        /// Adds the coordinates using the provided coordinate model.
        /// </summary>
        /// <param name="coordinates">The coordinate model containing the latitude and longitude values.</param>
        public void AddCoordinates(ICoordinateModel coordinates)
        {
            Coordinates = coordinates;
        }

        /// <summary>
        /// Adds the points response using the provided PointsResponseModel.
        /// </summary>
        /// <param name="pointsResponse">The PointsResponseModel to be added.</param>
        public void AddPointsResponse(PointsResponseModel pointsResponse)
        {
            PointsResponse = pointsResponse;
        }

        /// <summary>
        /// Adds the forecast response asynchronously.
        /// </summary>
        /// <param name="forecastResponse">The forecast response model to be added.</param>
        /// <returns>A task representing the asynchronous operation. The task result is a boolean indicating whether the forecast response was successfully added.</returns>
        public async Task<bool> AddForecastResponseAsync(ForecastResponseModel forecastResponse)
        {
            try
            {
                CurrentForecast = forecastResponse;
                ForecastPeriods = new List<Period>(forecastResponse.Periods);
                await GetWxPeriodIconAsync(ForecastPeriods);
                CurrentPeriodForecast = ForecastPeriods.First<Period>(p => p.Number == 1);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"UserSettingsParams: AddForecastResponseAsyc: {ex.Message}");
                return false;
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
