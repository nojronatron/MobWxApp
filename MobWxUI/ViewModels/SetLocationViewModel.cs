using CommunityToolkit.Mvvm.Input;
using MobWxUI.Data;
using MobWxUI.Helpers;
using MobWxUI.Models;
using MobWxUI.Views;
using System.Diagnostics;

namespace MobWxUI.ViewModels
{
    public class SetLocationViewModel : BaseViewModel
    {
        private readonly CurrentForecastCollection _currentForecastCollection;
        private IUserSettingsParams _userSettings;
        private IApiHelper _httpClient;

        public IAsyncRelayCommand LatLonEntryCommand { get; set; }

        private CoordinateModel _coordinateModel;
        public CoordinateModel CoordinateModel
        {
            get => _coordinateModel;
        }

        private string _latLonEntry = string.Empty;
        public string LatLonEntry
        {
            get => _latLonEntry;
            set => SetProperty(ref _latLonEntry, value);
        }

        private string _currentLocation = "Current Location";
        public string CurrentLocation
        {
            get => _currentLocation;
            set => SetProperty(ref _currentLocation, value);
        }

        public SetLocationViewModel(IUserSettingsParams userSettingsParams,
            CurrentForecastCollection currentForecastCollection,
            IApiHelper httpClient)
        {
            _currentForecastCollection = currentForecastCollection;
            _coordinateModel ??= new CoordinateModel();
            _userSettings = userSettingsParams;
            LatLonEntryCommand = new AsyncRelayCommand(MakeInitialApiCalls);
            _httpClient = httpClient;
        }

        private async Task MakeInitialApiCalls()
        {
            if (!await Task.Run(() => ProcessLatLonEntry()))
            {
                return;
            }
            if (!await Task.Run(() => GetForecast()))
            {
                return;
            }

            _currentForecastCollection.Add(_userSettings.CurrentForecast);
            await Shell.Current.GoToAsync(nameof(CurrentForecastPageView));
        }

        private async Task<bool> ProcessLatLonEntry()
        {
            // todo: move ProcessLatLonEntry() logic to a dedicated class
            Debug.WriteLine("MainPageViewModel ProcessLatLongEntry(): entered method.");

            if (string.IsNullOrWhiteSpace(LatLonEntry))
            {
                Debug.WriteLine("LatLonEntry was null or whitespace. Returning false.");
                return false;
            }

            string userEntry = LatLonEntry.Trim();
            string[] latLon = userEntry.Split(',');
            _coordinateModel = new CoordinateModel();

            if (
                _coordinateModel.SetLatitude(latLon[0].Trim())
                && _coordinateModel.SetLongitude(latLon[1].Trim()))
            {
                _userSettings.Coordinates = _coordinateModel;
                Debug.WriteLine("Latitude and Longitude set to User Settings successfully.");
            }

            string pointsResponse = await _httpClient.GetPointsAsync(_userSettings.Coordinates);

            if (string.IsNullOrWhiteSpace(pointsResponse))
            {
                Debug.WriteLine("PointsResponse was null or whitespace.");
                return false;
            }

            try
            {
                _userSettings.PointsResponse = RestResponseProcessor.ProcessPointsResponse(pointsResponse);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred while processing the API Points response: {ex.Message}");
                return false;
            }

            Debug.WriteLine("ProcessLatLonEntry is returning true!");
            return true;
        }

        private async Task<bool> GetForecast()
        {
            // todo: move GetForecast() logic to a dedicated class
            Debug.WriteLine("GetForecast method: Entered method.");
            string forecastResponse = await _httpClient.GetForecastAsync(_userSettings.PointsResponse);

            if (string.IsNullOrWhiteSpace(forecastResponse))
            {
                Debug.WriteLine("GetForecast method: forecastResponse was null or whitespace.");
                return false;
            }

            try
            {
                Debug.WriteLine("GetForecast method: Calling ProcessForecastResponse and setting result to _userSettings.CurrentForecast.");
                _userSettings.CurrentForecast = RestResponseProcessor.ProcessForecastResponse(forecastResponse);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"GetForecast method: An error occurred while processing the API Forecast response: {ex.Message}");
                return false;
            }

            Debug.WriteLine($"GetForecast method: Returning True!");
            return true;
        }
    }
}
