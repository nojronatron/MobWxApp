using MobWxUI.Views;

namespace MobWxUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CurrentForecastPageView), typeof(CurrentForecastPageView));
            Routing.RegisterRoute(nameof(SetLocationPageView), typeof(SetLocationPageView));
        }
    }
}
