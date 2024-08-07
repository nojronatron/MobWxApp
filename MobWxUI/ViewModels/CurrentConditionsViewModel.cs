﻿using MobWxUI.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using MobWxUI.Helpers;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace MobWxUI.ViewModels
{
    public partial class CurrentConditionsViewModel : BaseViewModel, IDisposable
    {
		#region Code source: CommunityToolkit Maui Sample ViewModels Converters ByteArrayToImageSourceConverterViewModel.cs
		readonly WeakEventManager imageDownloadFailedEventManager = new();
		readonly IApiHelper _apiHelper;
		[ObservableProperty, NotifyCanExecuteChangedFor(nameof(DownloadWxImageCommand))]
		bool isDownloadingImage;
		[ObservableProperty]
		byte[]? wxImageByteArray;
		bool CanDownloadWxImageCommandExecute => !IsDownloadingImage && WxImageByteArray is null;
		[RelayCommand(CanExecute = nameof(CanDownloadWxImageCommandExecute))]
		async Task DownloadWxImage(CancellationToken token)
		{
			IsDownloadingImage = true;

			try
			{
				WxImageByteArray = await _apiHelper.GetWeatherIconEnhancedAsync(ConditionIcon, token)
												   .ConfigureAwait(false);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				OnImageDownloadFailed(ex.Message);
			}
			finally
			{
				IsDownloadingImage = false;
			}
		}
		void OnImageDownloadFailed(in string message) =>
			imageDownloadFailedEventManager.HandleEvent(this, message, nameof(ImageDownloadFailed));

        public event EventHandler<string> ImageDownloadFailed
        {
            add => imageDownloadFailedEventManager.AddEventHandler(value);
            remove => imageDownloadFailedEventManager.RemoveEventHandler(value);
        }
        public void Dispose()
        {
            WxImageByteArray = null;
        }
        #endregion 

        const string DefaultStringData = "N/A";
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
		public Period LatestForecast { get; set; } = new Period();
        
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
			get {
				return _userSettingsParams is null
					? "No data"
					: _userSettingsParams.PointsResponse.RelativeLocation is null
						? "Current Conditions"
						: $"{_userSettingsParams.PointsResponse.RelativeLocation.GetSafeCityName()} Weather";
			} 
		}

        public string ForecastName
		{
			get => LatestForecast.Name!;
		}

		public string DefaultAlertIcon
		{
			get => "icons8_exclamation_mark_96.png";
        }

		// NOTE: The code cannot get here if POINTS or FORECAST responses are null
		public CurrentConditionsViewModel(
			IApiHelper apiHelper,
			IUserSettingsParams userSettingsParams)
		{
            _apiHelper = apiHelper;
            _userSettingsParams = userSettingsParams;
			LatestForecast = _userSettingsParams.CurrentPeriodForecast;

			if (LatestForecast is not null)
			{
				ConditionIcon = LatestForecast.Icon;
				RightNow = LatestForecast.ShortForecast ?? DefaultStringData;
				TempAndUnit = LatestForecast.Temp;
				Rh = LatestForecast.RelativeHumidity!.ToString();
				Dew = LatestForecast.Dewpoint!.ToString();
				PoP = LatestForecast.ProbabilityOfPrecipitation!.ToString();
				WindSpeedAndDirection = LatestForecast.Winds;
				DetailedConditionsText = LatestForecast.DetailedForecast ?? DefaultStringData;
			}
        }
    }
}
