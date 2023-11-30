using MobWxUI.Models;
using System.Diagnostics;
using System.Text.Json;

namespace MobWxUI.Helpers
{
    public static class RestResponseProcessor
    {
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public static PointsResponseModel ProcessPointsResponse(string jsonPointsResponse)
        {
            if (string.IsNullOrWhiteSpace (jsonPointsResponse))
            {
                throw new ArgumentNullException(nameof(jsonPointsResponse), "Arugment cannot be null or white space.");
            }

            try
            {
                PointsResponseModel? result = JsonSerializer.Deserialize<PointsResponseModel>(jsonPointsResponse, _jsonOptions);
                return result ?? throw new Exception("Unable to deserialize the Json points response.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred while processing PointsResponse: {ex.Message}");
                throw new ApplicationException("An error occurred while deserializeing the Json points response", ex);
            }
        }

        public static ForecastResponseModel ProcessForecastResponse(string jsonForecastResponse)
        {
            if (string.IsNullOrWhiteSpace(jsonForecastResponse))
            {
                throw new ArgumentNullException(nameof(jsonForecastResponse), "Argument cannot be null or empty.");
            }

            try
            {
                ForecastResponseModel? result = JsonSerializer.Deserialize<ForecastResponseModel>(jsonForecastResponse, _jsonOptions);
                return result ?? throw new Exception("Unable to deserialize the Json points response.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred while processing ForecastResponse: {ex.Message}");
                throw new ApplicationException("An error occurred while deserializing the Json forecast response", ex);
            }
        }
    }
}
