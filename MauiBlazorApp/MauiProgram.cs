using System;
using MauiBlazorApp.Data;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Essentials;
using Microsoft.Maui.Hosting;

namespace MauiBlazorApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            MauiAppBuilder builder = MauiApp.CreateBuilder();
            builder
                .RegisterBlazorMauiWebView()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddBlazorWebView();
            builder.Services.AddSingleton<WeatherForecastService>();

            builder.Services.AddHttpClient("WeatherApi", c =>
            {
                string baseAddress = "https://localhost:44393/";

                if (DeviceInfo.Platform == DevicePlatform.Android)
                {
                    baseAddress = "http://10.0.2.2:62042/";
                }
                else if (DeviceInfo.Platform == DevicePlatform.iOS)
                {
                    baseAddress = "http://localhost:62042/";
                }

                c.BaseAddress = new Uri(baseAddress);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
                c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            });

            return builder.Build();
        }
    }
}