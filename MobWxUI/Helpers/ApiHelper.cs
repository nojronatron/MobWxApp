using MobWxUI.Models;
using System.Diagnostics;

namespace MobWxUI.Helpers
{
    public class ApiHelper : IApiHelper
    {
        private readonly HttpClient _httpClient;
        private readonly string _userAgent = "(MobWxUI,jonrumsey.dev@gmail.com)";
        private readonly string _ldjsonAcceptHeader = "application/ld+json";
        private readonly string _imageAcceptHeader = "image/png";
        private readonly string _baseUrl = "https://api.weather.gov/";
        public HttpClient Apihelper => _httpClient;

        public ApiHelper()
        {
            _httpClient = new HttpClient();
        }


        /// <summary>
        /// Retrieves the weather icon asynchronously with timeouts and cancellation.
        /// Supports cancellation using IAsyncRelayCommand.Cancel to signal the cancellation of the Task.
        /// </summary>
        /// <param name="iconUrl">The URL of the weather icon.</param>
        /// <param name="token">A CancellationToken the caller can use to cancel this Task.</param>
        /// <returns>The byte array of the weather icon.</returns>
        public async Task<byte[]> GetWeatherIconEnhancedAsync(string iconUrl, CancellationToken token)
        {
            byte[] result = [];
            TimeSpan minDownloadTime = TimeSpan.FromSeconds(0.1); // reduce from 0.1
            TimeSpan maxDownloadTime = TimeSpan.FromSeconds(2.0); // reduce from 2.0
            //CancellationToken token = new();
            CancellationTokenSource maxDownloadTimeCts = new(maxDownloadTime);
            Task minDownloadTimeTask = Task.Delay(minDownloadTime, maxDownloadTimeCts.Token).WaitAsync(token);

            try
            {
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Add("Accept", _imageAcceptHeader);
                _httpClient.DefaultRequestHeaders.Add("User-Agent", _userAgent);
                result = await _httpClient.GetByteArrayAsync(iconUrl, maxDownloadTimeCts.Token)
                                          .WaitAsync(token)
                                          .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"GetWeatherIconEnhancedAsync exception for iconUrl {iconUrl}: {ex}");
            }

            return result;
        }

        public async Task<string> GetPointsAsync(ICoordinateModel coordinates)
        {
            string result = string.Empty;
            string pointsUrl = _baseUrl + "points/" + coordinates;
            Uri pointsBaseUri = new Uri(_baseUrl);
            Uri pointsUri = new Uri(pointsBaseUri, pointsUrl);

            try
            {
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Add("User-Agent", _userAgent);
                _httpClient.DefaultRequestHeaders.Add("Accept", _ldjsonAcceptHeader);
                HttpResponseMessage response = await _httpClient.GetAsync(pointsUri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("GetPointsAsync() response.IsSuccessStatusCode is true.");
                    result = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                // todo: log this exception
                Debug.WriteLine("GetPointsAsync() exception: " + ex.Message);

                if (ex.InnerException != null)
                {
                    // todo: log this exception
                    Debug.WriteLine("GetPointsAsync() inner exception: " + ex.InnerException.Message);
                }
            }

            return result;
        }

        public async Task<string> GetForecastAsync(IPointsResponseModel pointsResponse)
        {
            string result = string.Empty;

            if (pointsResponse == null || pointsResponse.Forecast == null)
            {
                return result;
            }

            Uri forecast = new Uri(pointsResponse.Forecast);

            try
            {
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Add("User-Agent", _userAgent);
                _httpClient.DefaultRequestHeaders.Add("Accept", _ldjsonAcceptHeader);
                HttpResponseMessage response = await _httpClient.GetAsync(forecast);

                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                // todo: log this exception
                Debug.WriteLine("GetPointsAsync() exception: " + ex.Message);
  
                if (ex.InnerException != null)
                {
                    // todo: log this exception
                    Debug.WriteLine("GetPointsAsync() inner exception: " + ex.InnerException.Message);
                }
            }

            return result;
        }
    }
}
