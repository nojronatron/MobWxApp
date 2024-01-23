using MobWxUI.Models;
using MobWxUI.ViewModels;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MobWxUI.Views;

public partial class ForecastView : BaseView<ForecastViewModel>
{
    public ForecastView(ForecastViewModel forecastViewModel) : base(forecastViewModel)
	{
		InitializeComponent();
	}
}
