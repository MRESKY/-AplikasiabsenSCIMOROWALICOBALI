using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using mobile-attendance-app.Models;
using mobile-attendance-app.Services;

namespace mobile-attendance-app.ViewModels
{
    public class AttendanceViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;
        private readonly CameraService _cameraService;
        private readonly LocationService _locationService;

        private AttendanceRecord _attendanceRecord;
        public AttendanceRecord AttendanceRecord
        {
            get => _attendanceRecord;
            set
            {
                _attendanceRecord = value;
                OnPropertyChanged();
            }
        }

        public ICommand CaptureSelfieCommand { get; }
        public ICommand SubmitAttendanceCommand { get; }

        public AttendanceViewModel()
        {
            _apiService = new ApiService();
            _cameraService = new CameraService();
            _locationService = new LocationService();

            AttendanceRecord = new AttendanceRecord();
            CaptureSelfieCommand = new Command(async () => await CaptureSelfie());
            SubmitAttendanceCommand = new Command(async () => await SubmitAttendance());
        }

        private async Task CaptureSelfie()
        {
            var selfieImage = await _cameraService.CaptureImageAsync();
            AttendanceRecord.SelfieImage = selfieImage;
            AttendanceRecord.Location = await _locationService.GetCurrentLocationAsync();
        }

        private async Task SubmitAttendance()
        {
            if (AttendanceRecord != null)
            {
                await _apiService.SubmitAttendanceAsync(AttendanceRecord);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}