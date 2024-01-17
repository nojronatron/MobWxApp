using CommunityToolkit.Mvvm.Input;
using MobWxUI.Helpers;
using System.Diagnostics;
using MobWxUI.Views;

namespace MobWxUI.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private IUserSettingsParams _userSettingsParams;
        private readonly IApiHelper _apiHelper;
        public IAsyncRelayCommand ClickDiscoveredLocation { get; set; }
        public IAsyncRelayCommand ClickSetLocation { get; set; }
        public IAsyncRelayCommand ClickCityState { get; set; }

        private string _informationMessage = string.Empty;
        public string InformationMessage
        {
            get => _informationMessage;
            set => SetProperty(ref _informationMessage, value);
        }

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
            ClickCityState = new AsyncRelayCommand(ClickCityStateCommand);
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

            // store the data in the collections (later: database) so that
            // when user uses Flyout to another page, the data is available
            string[] latLonArr = DiscoveredLocation.Split(',');
            _userSettingsParams.AddCoordinates(latLonArr[0], latLonArr[1]);
            await GetPointsAndForecast();
        }

        private async Task ClickSetLocationCommand()
        {
            // gather location data from CityState property and parse it
            // send the data to the GeoLocation service to get Lat, Lon
            // If non-null then fetch data and store in the collections (later: database)
            // show a message on-screen stating the location has been set
            // when user uses Flyout to another page, the data is available
            Debug.WriteLine("Executing MainPageVM ClickSetLocationCommand()");
            if (string.IsNullOrEmpty(LatLonEntry) || LatLonEntry.IndexOf(',') == -1)
            {
                InformationMessage = "Enter a valid latitude,longitude pair.";
                return;
            }

            string[] latLonArr = LatLonEntry.Split(',');
            _userSettingsParams.AddCoordinates(latLonArr[0], latLonArr[1]);
            await GetPointsAndForecast();
        }

        private async Task ClickCityStateCommand()
        {
            // utilize GeoLocation API to get Lat/Lon from City, State entry
            InformationMessage = "City State search is not yet implemented.";
            return;
        }

        private async Task GetPointsAndForecast()
        {
            // only call this after setting _userSettingsParams.Coordinates
            if (_userSettingsParams.HasCoordinates is false)
            {
                InformationMessage = "Location is not valid or is empty.";
                Debug.WriteLine($"Coordinates is null or empty. Returning.");
                return;
            }

            var jsonPointsResponse = await _apiHelper.GetPointsAsync(_userSettingsParams.Coordinates);
            var pointsResponse = RestResponseProcessor.ProcessPointsResponse(jsonPointsResponse);

            if (pointsResponse is null)
            {
                InformationMessage = "Weather data could not be retreived try again later.";
                Debug.WriteLine($"PointsResponse is null or Id is null. Returning.");
                return;
            }

            var jsonForecastResponse = await _apiHelper.GetForecastAsync(pointsResponse);
            var forecastResponse = RestResponseProcessor.ProcessForecastResponse(jsonForecastResponse);
            
            if (forecastResponse is null || forecastResponse.Periods.Count() < 1)
            {
                InformationMessage = "Weather data could not be retreived try again later.";
                Debug.WriteLine($"ForecastResponse is null or empty. Returning.");
                return;
            }
            
            _userSettingsParams.PointsResponse = pointsResponse;
            _userSettingsParams.CurrentForecast = forecastResponse;
            InformationMessage = string.Empty;
            await Shell.Current.GoToAsync(nameof(CurrentConditionsView), true);
        }
    }
}
