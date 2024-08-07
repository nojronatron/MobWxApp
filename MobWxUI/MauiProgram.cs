﻿using CommunityToolkit.Maui;
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
            builder.Services.AddTransient<Views.CurrentConditionsView>();
            builder.Services.AddTransient<Views.ForecastView>();
            builder.Services.AddSingleton<Views.AboutPageView>();

            // viewModels
            builder.Services.AddTransient<ViewModels.MainPageViewModel>();
            builder.Services.AddTransient<ViewModels.CurrentConditionsViewModel>();
            builder.Services.AddTransient<ViewModels.ForecastViewModel>();
            builder.Services.AddSingleton<ViewModels.AboutPageViewModel>();

            // collections

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
 