using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using mobile-attendance-app.Models;
using mobile-attendance-app.Services;

namespace mobile-attendance-app.ViewModels
{
    public class AttendanceViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;
        private readonly CameraService _cameraService;
        private readonly LocationService _locationService;

        private AttendanceRecord _attendanceRecord;
        public AttendanceRecord AttendanceRecord
        {
            get => _attendanceRecord;
            set => SetProperty(ref _attendanceRecord, value);
        }

        private string _jobDescription;

        /// <summary>
        /// Deskripsi pekerjaan yang diisi oleh karyawan.
        /// </summary>
        public string JobDescription
        {
            get => _jobDescription;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Deskripsi pekerjaan tidak boleh kosong.");
                SetProperty(ref _jobDescription, value);
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public ICommand CaptureSelfieCommand { get; }
        public ICommand SubmitAttendanceCommand { get; }

        public AttendanceViewModel(ApiService apiService, CameraService cameraService, LocationService locationService)
        {
            _apiService = apiService;
            _cameraService = cameraService;
            _locationService = locationService;

            AttendanceRecord = new AttendanceRecord();
            CaptureSelfieCommand = new Command(async () => await CaptureSelfie());
            SubmitAttendanceCommand = new Command(async () => await SubmitAttendance(), CanSubmitAttendance);
        }

        private async Task CaptureSelfie()
        {
            try
            {
                Console.WriteLine("Mengambil foto selfie...");
                var selfieImage = await _cameraService.CaptureImageAsync();
                AttendanceRecord.SelfieImage = selfieImage;

                Console.WriteLine("Mengambil lokasi...");
                AttendanceRecord.Location = await _locationService.GetCurrentLocationAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saat mengambil foto atau lokasi: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error", $"Gagal mengambil foto atau lokasi: {ex.Message}", "OK");
            }
        }

        private async Task SubmitAttendance()
        {
            IsLoading = true;
            try
            {
                if (AttendanceRecord == null)
                    throw new InvalidOperationException("AttendanceRecord tidak boleh null.");

                if (string.IsNullOrWhiteSpace(AttendanceRecord.SelfieImage))
                    throw new InvalidOperationException("SelfieImage tidak boleh kosong.");

                if (AttendanceRecord.Location == null)
                    throw new InvalidOperationException("Lokasi tidak boleh null.");

                if (string.IsNullOrWhiteSpace(JobDescription))
                    throw new InvalidOperationException("Deskripsi pekerjaan tidak boleh kosong.");

                await _apiService.SubmitAttendanceAsync(AttendanceRecord);
                Console.WriteLine("Data absensi berhasil dikirim.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saat mengirim data absensi: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error", "Gagal mengirim data absensi.", "OK");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private bool CanSubmitAttendance()
        {
            return AttendanceRecord != null &&
                   !string.IsNullOrWhiteSpace(AttendanceRecord.SelfieImage) &&
                   AttendanceRecord.Location != null &&
                   !string.IsNullOrWhiteSpace(JobDescription);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

builder.Services.AddSingleton<ApiService>();
builder.Services.AddSingleton<CameraService>();
builder.Services.AddSingleton<LocationService>();
builder.Services.AddTransient<AttendanceViewModel>();