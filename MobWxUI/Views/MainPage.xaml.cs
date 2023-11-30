using MobWxUI.ViewModels;

namespace MobWxUI.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel mainPageViewModel)
        {
            BindingContext = mainPageViewModel;
            InitializeComponent();
        }
    }
}
