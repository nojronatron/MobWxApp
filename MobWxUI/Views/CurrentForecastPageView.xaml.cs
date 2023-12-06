using MobWxUI.ViewModels;

namespace MobWxUI.Views;

public partial class CurrentForecastPageView : ContentPage
{
    public CurrentForecastPageView(CurrentForecastViewModel currentForecastViewModel)
	{
        BindingContext = currentForecastViewModel;
        InitializeComponent();
    }
}