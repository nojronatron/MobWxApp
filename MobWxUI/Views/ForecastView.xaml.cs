using MobWxUI.ViewModels;

namespace MobWxUI.Views;

public partial class ForecastView : BaseView<ForecastViewModel>
{
    public ForecastView(ForecastViewModel forecastViewModel) : base(forecastViewModel)
	{
		InitializeComponent();
	}
}
