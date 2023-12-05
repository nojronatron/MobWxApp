using MobWxUI.Data;
using MobWxUI.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using MobWxUI.Helpers;

namespace MobWxUI.ViewModels
{
    public class CurrentForecastViewModel : ObservableObject
    {
		const string DefaultStringData = "N/A";
		private readonly CurrentForecastCollection _currentForecastCollection;
		private readonly IUserSettingsParams _userSettingsParams;
        
		private string _rightNow = DefaultStringData;
		public string RightNow
		{
			get { return _rightNow; }
			set { _rightNow = value; }
		}
		private string _tempAndUnit = DefaultStringData;
		public string TempAndUnit
		{
			get { return _tempAndUnit; }
			set { _tempAndUnit = value; }
		}
		private string _rh = DefaultStringData;
		public string Rh
		{
			get { return _rh; }
			set { _rh = value; }
		}
		private string _dew = DefaultStringData;
		public string Dew
		{
			get { return _dew; }
			set { _dew = value; }
		}
		private string _pop = DefaultStringData;
		public string PoP
		{
			get { return _pop; }
			set { _pop = value; }
		}
		private string _windSpeedAndDirection = DefaultStringData;
		public string WindSpeedAndDirection
		{
			get { return _windSpeedAndDirection; }
			set { _windSpeedAndDirection = value; }
		}
        public Period LatestForecast { get; set; }
        
		private bool _detailedConditionsIsClosed;
		public bool DetailedConditionsIsClosed
		{
			get => _detailedConditionsIsClosed;
			set => SetProperty(ref _detailedConditionsIsClosed, value);
		}
        private string _detailedConditionsHeader = DefaultStringData;
		public string DetailedConditionsHeader
		{
			get => _detailedConditionsHeader;
			set => SetProperty(ref _detailedConditionsHeader, value);
		}
		private string _detailedConditionsText = DefaultStringData;
		public string DetailedConditionsText
		{
			get => _detailedConditionsText;
			set => SetProperty(ref _detailedConditionsText, value);
		}
		private string _conditionIcon = string.Empty;
		public string ConditionIcon
		{
			get => _conditionIcon;
			set => SetProperty(ref _conditionIcon, value);
		}

		public string ForecastLocation
		{
			get => _userSettingsParams.PointsResponse.RelativeLocation is null 
				? "Current Conditions" 
				: $"{_userSettingsParams.PointsResponse.RelativeLocation.GetSafeCityName()} Weather";
        }

        public string ForecastName
		{
			get => LatestForecast.Name!;
		}

		public string DefaultAlertIcon
		{
			get => "icons8_exclamation_mark_96.png";
        }

		public CurrentForecastViewModel(
			CurrentForecastCollection currentForecastCollection,
			IUserSettingsParams userSettingsParams)
		{
            _userSettingsParams = userSettingsParams;
            _currentForecastCollection = currentForecastCollection;
            _currentForecastCollection.Add(_userSettingsParams.CurrentForecast);
            LatestForecast = _currentForecastCollection.GetLatestForecast();
			
			RightNow = LatestForecast.ShortForecast;
			TempAndUnit = LatestForecast.Temp;
			Rh = LatestForecast.RelativeHumidity!.ToString();
			Dew = LatestForecast.Dewpoint!.ToString();
			PoP = LatestForecast.ProbabilityOfPrecipitation!.ToString();
			WindSpeedAndDirection = LatestForecast.Winds;
			DetailedConditionsText = LatestForecast.DetailedForecast;
			ConditionIcon = "icons_land_day_rain_20_rain_40_size_medium.png";
        }
    }
}
