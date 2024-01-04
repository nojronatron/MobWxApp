using MobWxUI.ViewModels;

namespace MobWxUI.Views;

public partial class DetailedConditionsView : BaseView<DetailedConditionsViewModel>
{
	public DetailedConditionsView(DetailedConditionsViewModel detailedConditionsViewModel) : base(detailedConditionsViewModel)
	{
		InitializeComponent();
		Title = "Conditions";
	}
}