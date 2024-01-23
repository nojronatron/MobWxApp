 using MobWxUI.Helpers;
using MobWxUI.Models;
using MobWxUI.ViewModels;
using System.Diagnostics;

namespace MobWxUI.Views
{
    public partial class MainPage : BaseView<MainPageViewModel>
    {
        private MainPageViewModel mainPageViewModel { get; set; }

        public MainPage(MainPageViewModel mainPageViewModel) :base(mainPageViewModel)
        {
            this.mainPageViewModel = mainPageViewModel;
            InitializeComponent();
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        protected override async void OnAppearing()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            base.OnAppearing();
#if ANDROID32_0_OR_GREATER
            Debug.WriteLine("***** MainPage code-behind OnAppearing() is executing.");
            var discoveredLocation = await AndroidLocationHelper.GetLocation();

            if (discoveredLocation is not null)
            {
                var shortLat = CoordinateModel.LimitToFourDecimalPlaces(discoveredLocation.Latitude.ToString());
                var shortLon = CoordinateModel.LimitToFourDecimalPlaces(discoveredLocation.Longitude.ToString());
                var plaintextLocation = $"{shortLat},{shortLon}";
                Debug.WriteLine($"***** MainPage OnAppearing() Android GetLocation() returned: {plaintextLocation}");
                mainPageViewModel.DiscoveredLocation = plaintextLocation;
                mainPageViewModel.LocationIsSet = true;
                return;
            }
            else
            {
                mainPageViewModel.DiscoveredLocation = "unknown";
                Debug.WriteLine($"***** MainPage OnAppearing() Android GetLocation returned null. Setting DiscoveredLocation to: unknown");
                return;
            }
#endif
#pragma warning disable CS0162 // Unreachable code detected
            mainPageViewModel.DiscoveredLocation = "unknown";
#pragma warning restore CS0162 // Unreachable code detected
            mainPageViewModel.LocationIsSet = false;
        }
    }
}
