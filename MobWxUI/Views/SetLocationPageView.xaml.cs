using MobWxUI.ViewModels;

namespace MobWxUI.Views;

public partial class SetLocationPageView : ContentPage
{
	public SetLocationPageView(SetLocationViewModel setLocationViewModel)
	{
		BindingContext = setLocationViewModel;
		InitializeComponent();
	}
}