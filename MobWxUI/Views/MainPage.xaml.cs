using MobWxUI.Helpers;
using MobWxUI.ViewModels;

namespace MobWxUI.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly IUserSettingsParams _userSettingsParams;
        private readonly IApiHelper _apiHelper;
        private bool _needsLocation;

        public bool NeedsLocation
        {
            get { return _needsLocation; }
            set { _needsLocation = value; }
        }


        public MainPage(
            MainPageViewModel mainPageViewModel,
            IUserSettingsParams userSettingsParams,
            IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
            _userSettingsParams = userSettingsParams;
            BindingContext = mainPageViewModel;
            NeedsLocation = true;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

#if ANDROID
            // todo: move this logic to a dedicated class
            Location? lastKnownLocation = await Geolocation.GetLastKnownLocationAsync();
            _userSettingsParams.AddCoordinates(lastKnownLocation);

            if (_userSettingsParams.HasCoordinates)
            {
                var pointsResponse = await _apiHelper.GetPointsAsync(_userSettingsParams.Coordinates);

                if (!string.IsNullOrEmpty(pointsResponse))
                {
                    var processedPoints = RestResponseProcessor.ProcessPointsResponse(pointsResponse);

                    if (processedPoints != null)
                    {
                        _userSettingsParams.PointsResponse = processedPoints;
                        var forecastResponse = await _apiHelper.GetForecastAsync(_userSettingsParams.PointsResponse);

                        if (!string.IsNullOrEmpty(forecastResponse))
                        {
                            var processedForecast = RestResponseProcessor.ProcessForecastResponse(forecastResponse);

                            if (processedForecast != null)
                            {
                                _userSettingsParams.CurrentForecast = processedForecast;
                                NeedsLocation = false;
                                await Shell.Current.GoToAsync(nameof(CurrentForecastPageView));
                                return;
                            }
                        }
                    }
                }
            }
#endif
            await Shell.Current.GoToAsync(nameof(SetLocationPageView));
        }
    }
}
