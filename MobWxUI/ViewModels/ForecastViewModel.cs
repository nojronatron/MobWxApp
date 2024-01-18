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

        // todo: show a sub-classed view of 14 forecast data days (bootstrap card-style)
        public ForecastViewModel()
        {

        }
    }
}
