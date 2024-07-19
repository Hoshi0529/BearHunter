using Microsoft.Extensions.Logging;
using Maui.GoogleMaps.Hosting;

namespace BearHunter
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
            builder.Logging.AddDebug();
#endif

#if ANDROID
            builder.UseGoogleMaps();
#elif IOS
         builder.UseGoogleMaps("AIzaSyB7ihdAHiq3osky-8D-r6iNNmB5GtdPhYk"); // ここに先ほど取得したAPIキーを入れる
#endif
            return builder.Build();
        }
    }

}
