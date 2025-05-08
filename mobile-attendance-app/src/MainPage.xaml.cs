<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="MobileAttendanceApp.MainPage"
             Title="Mobile Attendance App">

    <Grid Padding="20" RowDefinitions="Auto, Auto, Auto, Auto, *">
        <!-- Judul Halaman -->
        <Label Grid.Row="0" Text="Welcome to the Mobile Attendance App"
               FontSize="24"
               HorizontalOptions="Center" />

        <!-- Tombol Login -->
        <Button Grid.Row="1" Text="Login"
                Command="{Binding NavigateToLoginCommand}"
                HorizontalOptions="Center"
                ImageSource="login_icon.png" />

        <!-- Tombol Record Attendance -->
        <Button Grid.Row="2" Text="Record Attendance"
                Command="{Binding NavigateToAttendanceCommand}"
                HorizontalOptions="Center"
                ImageSource="attendance_icon.png" />

        <!-- Tombol Admin Panel -->
        <Button Grid.Row="3" Text="Admin Panel"
                Command="{Binding NavigateToAdminCommand}"
                HorizontalOptions="Center"
                ImageSource="admin_icon.png" />
    </Grid>
</ContentPage>