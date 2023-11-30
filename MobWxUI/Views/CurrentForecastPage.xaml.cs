using MobWxUI.ViewModels;

namespace MobWxUI.Views;

public partial class CurrentForecastPage : ContentPage
{
    public CurrentForecastPage(CurrentForecastViewModel currentForecastViewModel)
	{
        BindingContext = currentForecastViewModel;
        InitializeComponent();
    }
}