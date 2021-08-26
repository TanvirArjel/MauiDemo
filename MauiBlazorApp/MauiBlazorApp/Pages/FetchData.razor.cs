using System.Threading.Tasks;
using MauiBlazorApp.Data;
using Microsoft.AspNetCore.Components;

namespace MauiBlazorApp.Pages
{
    public partial class FetchData
    {
        [Inject]
        private WeatherForecastService ForecastService { get; set; }

        private WeatherForecast[] forecasts;

        protected override async Task OnInitializedAsync()
        {
            forecasts = await ForecastService.GetForecastAsync();
        }
    }
}
