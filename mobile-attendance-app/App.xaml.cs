using System;
using Microsoft.Maui.Controls;
using mobile_attendance_app.Services;

namespace mobile_attendance_app
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Penanganan kesalahan global
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Console.WriteLine($"Unhandled exception: {e.ExceptionObject}");
            };

            TaskScheduler.UnobservedTaskException += (sender, e) =>
            {
                Console.WriteLine($"Unobserved task exception: {e.Exception}");
                e.SetObserved();
            };

            // Set the main page
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            base.OnStart();
            Console.WriteLine("Application started.");
        }

        protected override void OnSleep()
        {
            base.OnSleep();
            Console.WriteLine("Application is sleeping.");
        }

        protected override void OnResume()
        {
            base.OnResume();
            Console.WriteLine("Application resumed.");
        }
    }
}

<Shell xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
       xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
       xmlns:views="clr-namespace:MobileAttendanceApp.Views"
       x:Class="MobileAttendanceApp.AppShell">

    <ShellContent Title="Admin Page"
                  ContentTemplate="{DataTemplate views:AdminPage}" />
</Shell>