using MobWxUI.ViewModels;

namespace MobWxUI.Views;

public partial class AboutPageView : BaseView<AboutPageViewModel>
{
	public AboutPageView(AboutPageViewModel aboutPageViewModel) : base(aboutPageViewModel)
	{
		InitializeComponent();
	}
}