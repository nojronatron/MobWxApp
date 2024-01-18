using MobWxUI.Models;
using System.Diagnostics;
using System.Text.Json;

namespace MobWxUI.Helpers
{
    public static class RestResponseProcessor
    {
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public static PointsResponseModel? ProcessPointsResponse(string jsonPointsResponse)
        {
            if (string.IsNullOrWhiteSpace(jsonPointsResponse))
            {
                return null;
            }

            try
            {
                return JsonSerializer.Deserialize<PointsResponseModel?>(jsonPointsResponse, _jsonOptions);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred while processing PointsResponse: {ex.Message}");
                throw new ApplicationException("An error occurred while deserializeing the Json points response", ex);
            }
        }

        public static ForecastResponseModel? ProcessForecastResponse(string jsonForecastResponse)
        {
            if (string.IsNullOrWhiteSpace(jsonForecastResponse))
            {
                return null;
            }

            try
            {
                return JsonSerializer.Deserialize<ForecastResponseModel?>(jsonForecastResponse, _jsonOptions);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred while processing ForecastResponse: {ex.Message}");
                throw new ApplicationException("An error occurred while deserializing the Json forecast response", ex);
            }
        }
    }
}
