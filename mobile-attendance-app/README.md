# Mobile Attendance App

## Overview
The Mobile Attendance App is designed for internal company use, allowing employees to mark their attendance through a mobile application. The app captures a selfie and records the user's geographical location at the time of attendance. The collected data is then sent to an admin webpage for monitoring and record-keeping.

## Features
- User authentication for secure access.
- Attendance marking with selfie capture.
- Automatic location tracking using GPS.
- Admin interface for viewing attendance records.

## Project Structure
```
mobile-attendance-app
├── src
│   ├── App.xaml
│   ├── MainPage.xaml
│   ├── Views
│   │   ├── LoginPage.xaml
│   │   ├── AttendancePage.xaml
│   │   └── AdminPage.xaml
│   ├── ViewModels
│   │   ├── LoginViewModel.cs
│   │   ├── AttendanceViewModel.cs
│   │   └── AdminViewModel.cs
│   ├── Models
│   │   ├── User.cs
│   │   ├── AttendanceRecord.cs
│   │   └── Location.cs
│   └── Services
│       ├── ApiService.cs
│       ├── LocationService.cs
│       └── CameraService.cs
├── Resources
│   ├── Fonts
│   ├── Images
│   └── Styles
├── Platforms
│   ├── Android
│   ├── iOS
│   ├── Windows
│   └── MacCatalyst
├── App.xaml.cs
├── mobile-attendance-app.csproj
└── README.md
```

## Setup Instructions
1. Clone the repository to your local machine.
2. Open the project in your preferred IDE.
3. Restore the project dependencies.
4. Configure platform-specific settings as needed.
5. Build and run the application on your desired platform.

## Usage
- **Login Page**: Users can enter their credentials to access the app.
- **Attendance Page**: Users can take a selfie and record their attendance.
- **Admin Page**: Administrators can view and manage attendance records.

## Contributing
Contributions are welcome! Please submit a pull request or open an issue for any suggestions or improvements.

## License
This project is licensed under the MIT License. See the LICENSE file for details.