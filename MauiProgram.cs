using Microsoft.Extensions.Logging;
using ApplicationFundamentals.View;
using ApplicationFundamentals.Services;


namespace ApplicationFundamentals
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

#if DEBUG
            //Services
            builder.Services.AddSingleton<IMyService, MyService>();

            //Content Page
            builder.Services.AddTransient<StartPage>();

    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
