using CommunityToolkit.Mvvm.Input;
using MobWxUI.Helpers;
using System.Diagnostics;

namespace MobWxUI.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private IUserSettingsParams _userSettingsParams;
        private readonly IApiHelper _apiHelper;
        public IAsyncRelayCommand ClickDiscoveredLocation { get; set; }
        public IAsyncRelayCommand ClickSetLocation { get; set; }

        public IUserSettingsParams UserSettingsParams
        {
            get => _userSettingsParams;
            set => SetProperty(ref _userSettingsParams, value);
        }

        private string _discoveredLocation = string.Empty;
        public string DiscoveredLocation {
            get => _discoveredLocation; 
            set => SetProperty(ref _discoveredLocation, value); 
        }

        private string _locationSetMessage = string.Empty;
        public string LocationSetMessage
        {
            get => LocationIsSet ? "Location set!" : "Set a location";
            set => SetProperty(ref _locationSetMessage, value);
        }

        public bool LocationIsSet { get; set; } = false;

        private bool _needsLocation = true;
        public bool NeedsLocation
        {
            get { return _needsLocation; }
            set { _needsLocation = value; }
        }

        public string CityState { get; set; } = string.Empty;

        private string _latLonEntry = string.Empty;
        public string LatLonEntry
        {
            get => _latLonEntry;
            set => SetProperty(ref _latLonEntry, value);
        }
        
        public MainPageViewModel(
            IUserSettingsParams userSettingsParams,
            IApiHelper apiHelper
            )
        {
            _apiHelper = apiHelper;
            _userSettingsParams = userSettingsParams;
            ClickDiscoveredLocation = new AsyncRelayCommand(ClickDiscoveredLocationCommand);
            ClickSetLocation = new AsyncRelayCommand(ClickSetLocationCommand);
        }

        private async Task ClickDiscoveredLocationCommand()
        {
            Debug.WriteLine("Executing MainPageVM ClickDiscoveredLocationCommand()");

            // gather location data from DiscoveredLocation property and parse it
            if (string.IsNullOrEmpty(DiscoveredLocation))
            {
                Debug.WriteLine("DiscoveredLocation was null or empty. Returning.");
                return;
            } else
            {
                Debug.WriteLine($"DiscoveredLocation is not null => {DiscoveredLocation}");
            }

            // store the data in the collections (later: database)
            
            // when user uses Flyout to another page, the data is available
            // show a message on-screen stating the location has been set

            return;
        }

        private async Task ClickSetLocationCommand()
        {
            // gather location data from CityState property and parse it
            // send the data to the GeoLocation service to get Lat, Lon
            // If non-null then fetch data and store in the collections (later: database)
            // show a message on-screen stating the location has been set
            // when user uses Flyout to another page, the data is available
            Debug.WriteLine("Executing MainPageVM ClickSetLocationCommand()");

            return;
        }
    }
}
