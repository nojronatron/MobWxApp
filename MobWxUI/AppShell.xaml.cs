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
            Routing.RegisterRoute(nameof(CurrentConditionsView), typeof(CurrentConditionsView));
            Routing.RegisterRoute(nameof(ForecastView), typeof(ForecastView));
            Routing.RegisterRoute(nameof(AboutPageView), typeof(AboutPageView));
        }
    }
}
