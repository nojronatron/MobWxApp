using MobWxUI.Models;

namespace MobWxUI.Helpers
{
    public interface ILocationHelper
    {
        void CancelRequest();
        Task<ICoordinateModel> GetCachedLocationAsync();
        Task<ICoordinateModel> GetCurrentLocationAsync();
    }
}