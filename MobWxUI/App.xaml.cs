
namespace MobWxUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

#if WINDOWS
            window.X = 200;
            window.Y = 300;
            window.Width = 500;
            window.Height = 800;
            window.MinimumWidth = 500;
            window.MinimumHeight = 800;
#endif
            return window;
        }
    }
}
