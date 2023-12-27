using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace MobWxUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            // helpers
            builder.Services.AddSingleton<Helpers.IApiHelper, Helpers.ApiHelper>();
            builder.Services.AddSingleton<Helpers.IUserSettingsParams, Helpers.UserSettingsParams>();

            // views
            builder.Services.AddTransient<Views.MainPage>();
            builder.Services.AddTransient<Views.SetLocationPageView>();
            builder.Services.AddTransient<Views.CurrentForecastPageView>();
            builder.Services.AddSingleton<Views.AboutPageView>();

            // viewModels
            builder.Services.AddTransient<ViewModels.MainPageViewModel>();
            builder.Services.AddTransient<ViewModels.SetLocationViewModel>();
            builder.Services.AddTransient<ViewModels.CurrentForecastViewModel>();
            builder.Services.AddSingleton<ViewModels.AboutPageViewModel>();

            // collections
            builder.Services.AddSingleton<Data.CurrentForecastCollection>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
 