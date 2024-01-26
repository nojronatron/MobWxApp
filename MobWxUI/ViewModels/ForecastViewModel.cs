using MobWxUI.Helpers;
using MobWxUI.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MobWxUI.ViewModels
{
    public class ForecastViewModel : BaseViewModel
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

            if (userSettingsParams is not null && userSettingsParams.PointsResponse is not null)
            {
                Debug.WriteLine($"User settings is not null and points response has data.");
                ForecastLocation = UserSettingsParams.PointsResponse.RelativeLocation.GetSafeCityName();

                if (userSettingsParams is not null && userSettingsParams.HasForecastResponse)
                {
                    Debug.WriteLine($"User settings is not null and it has a forecast response.");
                    Forecasts = new ObservableCollection<Period>(UserSettingsParams.ForecastPeriods);
                }
                else
                {
                    Debug.WriteLine($"ForecastViewModel: userSettingsParams is null, or does not have a response to the Forecast request.");
                    Forecasts = new ObservableCollection<Period>();
                }
            }
            else
            {
                Debug.WriteLine($"ForecastViewModel: userSettingsParams is null.");
            }
        }
    }
}
