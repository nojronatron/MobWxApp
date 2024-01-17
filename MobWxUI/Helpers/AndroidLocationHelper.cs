using System.Diagnostics;

namespace MobWxUI.Helpers
{
    internal class AndroidLocationHelper
    {
        public AndroidLocationHelper()
        {

        }
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public static async Task<Location> GetLocation()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            Debug.WriteLine("***** AndroidLocationHelper.GetLocation() is executing.");
            Location lastKnownLocation = new();

#if ANDROID32_0_OR_GREATER
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            lastKnownLocation = await Geolocation.GetLastKnownLocationAsync();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (lastKnownLocation is null)
            {
                lastKnownLocation = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Medium));
            }
#endif
#pragma warning disable CS8603 // Possible null reference return.
            return lastKnownLocation;
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
