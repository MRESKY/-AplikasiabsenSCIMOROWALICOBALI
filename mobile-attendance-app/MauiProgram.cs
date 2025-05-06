using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace MobileAttendanceApp
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

            // Tambahkan layanan yang diperlukan di sini
            builder.Services.AddSingleton<ApiService>();
            builder.Services.AddSingleton<LocationService>();
            builder.Services.AddSingleton<CameraService>();

            return builder.Build();
        }
    }
}