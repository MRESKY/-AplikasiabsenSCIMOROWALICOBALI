using Android.App;
using Android.Runtime;

namespace MobileAttendanceApp
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}

Platforms\Android\Resources\
    drawable\icon.png          // Ikon aplikasi
    drawable\splash.png        // Splash screen
    values\colors.xml          // Warna tema
    values\styles.xml          // Gaya tema