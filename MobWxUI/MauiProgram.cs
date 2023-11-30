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
            builder.Services.AddTransient<Views.CurrentForecastPage>();

            // viewModels
            builder.Services.AddTransient<ViewModels.MainPageViewModel>();
            builder.Services.AddTransient<ViewModels.CurrentForecastViewModel>();

            // collections
            builder.Services.AddSingleton<Data.CurrentForecastCollection>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
 