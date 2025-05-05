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

            // Initialize services
            DependencyService.Register<ApiService>();
            DependencyService.Register<LocationService>();
            DependencyService.Register<CameraService>();

            // Set the main page
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}