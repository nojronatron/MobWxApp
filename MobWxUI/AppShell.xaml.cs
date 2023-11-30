using MobWxUI.Views;

namespace MobWxUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CurrentForecastPage), typeof(CurrentForecastPage));
        }
    }
}
