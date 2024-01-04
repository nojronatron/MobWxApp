using MobWxUI.ViewModels;

namespace MobWxUI.Views;

public partial class SetLocationPageView : BaseView<SetLocationViewModel>
{
	public SetLocationPageView(SetLocationViewModel setLocationViewModel) : base(setLocationViewModel)
	{
		InitializeComponent();
	}
}
