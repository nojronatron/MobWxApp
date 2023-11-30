using MobWxUI.Models;

namespace MobWxUI.Helpers
{
    public interface IApiHelper
    {
        HttpClient Apihelper { get; }

        Task<string> GetForecastAsync(IPointsResponseModel pointsResponse);
        Task<string> GetPointsAsync(ICoordinateModel coordinates);
    }
}