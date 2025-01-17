using Microsoft.Extensions.Logging;
using TrackApp_alish.Services;

namespace TrackApp_alish
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
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddTransient<UserService>();
            builder.Services.AddSingleton<UserService>();
            builder.Services.AddScoped<AuthenticationService>();
            builder.Services.AddScoped<AuthenticationService>();
            builder.Services.AddScoped<ITransactionService, TransactionService>();
            builder.Services.AddSingleton<ITransactionService, TransactionService>();
            builder.Services.AddSingleton<IDebtService, DebtService>();
            builder.Services.AddScoped<IDebtService, DebtService>();



#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
