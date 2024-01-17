using MobWxUI.Data;
using MobWxUI.Helpers;
using MobWxUI.Models;

namespace MobWxUI.ViewModels
{
    public class SetLocationViewModel : BaseViewModel
    {
        private readonly CurrentForecastCollection _currentForecastCollection;
        private IUserSettingsParams _userSettings;
        private IApiHelper _httpClient;

        private CoordinateModel _coordinateModel;
        public CoordinateModel CoordinateModel
        {
            get => _coordinateModel;
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
            _httpClient = httpClient;
        }
    }
}
