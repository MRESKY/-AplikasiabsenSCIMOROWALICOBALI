using Microsoft.Maui.Controls;

namespace MobileAttendanceApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}