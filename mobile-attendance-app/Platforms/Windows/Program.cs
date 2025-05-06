using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace MobileAttendanceApp.WinUI
{
    public static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var app = MauiWinUIApplication.CreateMauiApp();
            app.Run(args);
        }
    }
}