using System.Diagnostics;

namespace MobWxUI.Helpers
{
    internal class AndroidLocationHelper
    {
        public AndroidLocationHelper()
        {

        }
        public static async Task<Location?> GetLocation()
        {
            Debug.WriteLine("***** AndroidLocationHelper.GetLocation() is executing.");
            Location? lastKnownLocation = new();

            lastKnownLocation = await Geolocation.GetLastKnownLocationAsync();

            if (lastKnownLocation is null)
            {
                lastKnownLocation = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Medium));
            }

            return lastKnownLocation;
        }
    }
}
