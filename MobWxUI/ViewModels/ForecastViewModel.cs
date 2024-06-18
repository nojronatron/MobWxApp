using CommunityToolkit.Mvvm.Input;
using MobWxUI.Helpers;
using MobWxUI.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MobWxUI.ViewModels
{
    public partial class ForecastViewModel : BaseViewModel
    {
        private string _forecastLocation = "Location Placeholder";

        public string ForecastLocation
        {
            get => _forecastLocation;
            set => SetProperty(ref _forecastLocation, value);
        }

        private ObservableCollection<Period> _forecasts = new();
        public ObservableCollection<Period> Forecasts
        {
            get => _forecasts;
            set => SetProperty(ref _forecasts, value);
        }

        public IUserSettingsParams UserSettingsParams { get; }

        public ForecastViewModel(IUserSettingsParams userSettingsParams)
        {
            UserSettingsParams = userSettingsParams;
        }

        [RelayCommand]
        private void Appearing()
        {
            try
            {
                ForecastLocation = UserSettingsParams.PointsResponse.RelativeLocation.GetSafeCityName();
                Forecasts = new ObservableCollection<Period>(UserSettingsParams.ForecastPeriods);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ForecastViewModel Appearing error: {ex.Message}");
            }
        }

        [RelayCommand]
        private void Disappearing()
        {
            try
            {
                ForecastLocation = string.Empty;
                Forecasts = new ObservableCollection<Period>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ForecastViewModel Disappearing error: {ex.Message}");
            }
        }
    }
}
