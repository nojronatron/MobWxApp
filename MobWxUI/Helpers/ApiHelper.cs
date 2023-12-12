using MobWxUI.Models;

namespace MobWxUI.Helpers
{
    public class ApiHelper : IApiHelper
    {
        private readonly HttpClient _httpClient;
        private readonly string _userAgent = "(Exploring,jonrumsey.dev@gmail.com)";
        private readonly string _acceptHeader = "application/ld+json";
        private readonly string _baseUrl = "https://api.weather.gov/";
        public HttpClient Apihelper => _httpClient;

        public ApiHelper()
        {
            _httpClient = new HttpClient();
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
                _httpClient.DefaultRequestHeaders.Add("Accept", _acceptHeader);
                HttpResponseMessage response = await _httpClient.GetAsync(pointsUri);

                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                // todo: log this exception

                if (ex.InnerException != null)
                {
                    // todo: log this exception
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
                _httpClient.DefaultRequestHeaders.Add("Accept", _acceptHeader);
                HttpResponseMessage response = await _httpClient.GetAsync(forecast);

                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                // todo: log this exception
                if (ex.InnerException != null)
                {
                    // todo: log this exception
                }
            }

            return result;
        }
    }
}
