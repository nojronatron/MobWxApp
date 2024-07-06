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

        private bool _clickDiscoveredLocationEnabled;

        public bool ClickDiscoveredLocationEnabled
        {
            get => _clickDiscoveredLocationEnabled; 
            set => SetProperty(ref _clickDiscoveredLocationEnabled, value); 
        }

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
            get => _locationSetMessage;
            set => SetProperty(ref _locationSetMessage, value);
        }

        private bool _locationIsSet = false;
        public bool LocationIsSet
        {
            get => _locationIsSet;
            set
            {
                SetProperty(ref _locationIsSet, value);
                SetProperty(ref _locationSetMessage, value ? "Location is set." : "Location is not set.");
            }
        }

        private string _cityState = string.Empty;
        public string CityState
        {
            get => _cityState;
            set => SetProperty(ref _cityState, value);
        }

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
            ClickDiscoveredLocationEnabled = !DiscoveredLocation.Equals("unknown");
            ClickDiscoveredLocation = new AsyncRelayCommand(ClickDiscoveredLocationCommand);
            ClickSetLocation = new AsyncRelayCommand(ClickSetLocationCommand);
            ClickCityState = new AsyncRelayCommand(ClickCityStateCommand);
        }

        private async Task ClickDiscoveredLocationCommand()
        {
            Debug.WriteLine("Executing MainPageVM ClickDiscoveredLocationCommand()");

            // gather location data from DiscoveredLocation property and parse it
            if (string.IsNullOrEmpty(DiscoveredLocation) || DiscoveredLocation.Equals("unknown"))
            {
                Debug.WriteLine("DiscoveredLocation was null or empty. Returning.");
                ClickDiscoveredLocationEnabled = false;
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

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private async Task ClickCityStateCommand()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
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

            if (string.IsNullOrEmpty(jsonPointsResponse))
            {
                InformationMessage = "Weather data could not be retreived try again later.";
                Debug.WriteLine($"jsonPointsResponse is null or empty. Returning.");
                return;
            }

            var pointsResponse = RestResponseProcessor.ProcessPointsResponse(jsonPointsResponse);

            if (pointsResponse is null)
            {
                InformationMessage = "Weather data could not be retreived try again later.";
                Debug.WriteLine($"PointsResponse is null or Id is null. Returning.");
                return;
            }

            var jsonForecastResponse = await _apiHelper.GetForecastAsync(pointsResponse);

            if(string.IsNullOrEmpty(jsonForecastResponse))
            {
                InformationMessage = "Weather data could not be retreived try again later.";
                Debug.WriteLine($"jsonForecastResponse is null or empty. Returning.");
                return;
            }

            var forecastResponse = RestResponseProcessor.ProcessForecastResponse(jsonForecastResponse);
            
            if (forecastResponse is null || forecastResponse.Periods.Count() < 1)
            {
                InformationMessage = "Weather data could not be retreived try again later.";
                Debug.WriteLine($"ForecastResponse is null or empty. Returning.");
                return;
            }
            
            _userSettingsParams.AddPointsResponse(pointsResponse);
            await _userSettingsParams.AddForecastResponseAsync(forecastResponse);
            InformationMessage = string.Empty;
            await Shell.Current.GoToAsync(nameof(CurrentConditionsView), true);
        }
    }
}
