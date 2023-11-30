using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using MobWxUI.Helpers;
using MobWxUI.Models;
using MobWxUI.Views;
using System.Diagnostics;
using MobWxUI.Data;

namespace MobWxUI.ViewModels
{
    public class MainPageViewModel : ObservableObject
    {
        private readonly CurrentForecastCollection _currentForecastCollection;
        private string IconPlaceholderLarge = "icons8_question_mark_96.png";
        private CoordinateModel _coordinateModel;
        private IApiHelper _httpClient;
        private IUserSettingsParams _userSettings;
        public IAsyncRelayCommand LatLonEntryCommand { get; set; }

        private string _latLonEntry;
        public string LatLonEntry
        {
            get
            {
                return _latLonEntry;
            }
            set
            {
                if (_latLonEntry != value)
                {
                    _latLonEntry = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainPageViewModel(IApiHelper httpClient, 
            CurrentForecastCollection currentForecastCollection,
            IUserSettingsParams userSettingsParams)
        {
            _latLonEntry = string.Empty;
            _coordinateModel = new CoordinateModel();
            _httpClient = httpClient;
            _userSettings = userSettingsParams;
            LatLonEntryCommand = new AsyncRelayCommand(MakeInitialApiCalls);
            _currentForecastCollection = currentForecastCollection;
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
            await Shell.Current.GoToAsync(nameof(CurrentForecastPage));
        }

        private async Task<bool> ProcessLatLonEntry()
        {
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
