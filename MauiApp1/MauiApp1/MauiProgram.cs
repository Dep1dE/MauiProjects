using MauiApp1.Services;
using Microsoft.Maui.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace MauiApp1
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
            builder.Services.AddTransient<IDbService, SQLiteService>();
            //builder.Services.AddTransient<IRateService, RateService>();
            builder.Services.AddScoped<SQLiteDemo>();
            builder.Services.AddScoped<RateDemo>();
            builder.Services.AddHttpClient<IRateService, RateService>(client =>
            {
                client.BaseAddress = new Uri("https://www.nbrb.by/api/exrates/rates");
            });

#if DEBUG0
    		builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}
