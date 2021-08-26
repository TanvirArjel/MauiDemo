using System;
using MauiBlazorApp.Data;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Essentials;
using Microsoft.Maui.Hosting;

[assembly: XamlCompilationAttribute(XamlCompilationOptions.Compile)]

namespace MauiBlazorApp
{
    public class Startup : IStartup
    {
        public void Configure(IAppHostBuilder appBuilder)
        {
            appBuilder
                .RegisterBlazorMauiWebView()
                .UseMicrosoftExtensionsServiceProviderFactory()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                })
                .ConfigureServices(services =>
                {
                    services.AddBlazorWebView();
                    services.AddSingleton<WeatherForecastService>();
                    services.AddHttpClient("WeatherApi", c =>
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
                    ////.ConfigurePrimaryHttpMessageHandler(x => new HttpClientHandler()
                    ////{
                    ////    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
                    ////    {
                    ////        if (cert.Issuer.Equals("CN=localhost"))
                    ////        {
                    ////            return true;
                    ////        }

                    ////        return errors == System.Net.Security.SslPolicyErrors.None;
                    ////    }
                    ////});
                });
        }
    }
}