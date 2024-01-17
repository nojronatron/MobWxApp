 using MobWxUI.Helpers;
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

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Debug.WriteLine("***** MainPage code-behind OnAppearing() is executing.");
            var discoveredLocation = await AndroidLocationHelper.GetLocation();
            var plaintextLocation = $"{discoveredLocation.Latitude},{discoveredLocation.Longitude}";

            if (discoveredLocation is not null)
            {
                Debug.WriteLine($"***** MainPage OnAppearing() Android GetLocation() returned: {plaintextLocation}");
            }
            else
            {
                plaintextLocation = "unknown";
                Debug.WriteLine($"***** MainPage OnAppearing() Android GetLocation returned null. Setting DiscoveredLocation to: {plaintextLocation}");
            }

            mainPageViewModel.DiscoveredLocation = plaintextLocation;
        }
    }
}
