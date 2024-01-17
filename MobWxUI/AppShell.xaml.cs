using MobWxUI.Views;
using System.Windows.Input;

namespace MobWxUI
{
    public partial class AppShell : Shell
    {
        public ICommand ExitCommand { get; set; }

        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(SetLocationPageView), typeof(SetLocationPageView));
            Routing.RegisterRoute(nameof(CurrentForecastPageView), typeof(CurrentForecastPageView));
            //Routing.RegisterRoute(nameof(DetailedConditionsView), typeof(DetailedConditionsView));
            Routing.RegisterRoute(nameof(AboutPageView), typeof(AboutPageView));
        }
    }
}
