﻿using MobWxUI.Models;
using System.Diagnostics;

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
            Debug.WriteLine($"GetPointsAsync method: Entered method.");
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
                    Debug.WriteLine($"ApiHelper GetPointsAsync response is Success Status Code.");
                    result = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"HttpClient encountered an error calling {pointsUri}: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Debug.WriteLine($"Here is the inner exception: {ex.InnerException.Message}");
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
                Debug.WriteLine($"HttpClient encountered an error calling {forecast}: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Debug.WriteLine($"Here is the inner exception: {ex.InnerException.Message}");
                }
            }

            return result;
        }
    }
}
