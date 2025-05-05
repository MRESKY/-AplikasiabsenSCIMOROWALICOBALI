using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using mobile-attendance-app.Models;
using mobile-attendance-app.Services;

namespace mobile-attendance-app.ViewModels
{
    /// <summary>
    /// ViewModel for managing attendance records in the admin panel.
    /// </summary>
    public class AdminViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;

        /// <summary>
        /// The collection of attendance records.
        /// </summary>
        public ObservableCollection<AttendanceRecord> AttendanceRecords { get; set; }

        private bool _isLoading;
        /// <summary>
        /// Indicates whether data is being loaded.
        /// </summary>
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminViewModel"/> class.
        /// </summary>
        /// <param name="apiService">The API service for fetching attendance records.</param>
        public AdminViewModel(ApiService apiService)
        {
            _apiService = apiService;
            AttendanceRecords = new ObservableCollection<AttendanceRecord>();
            Task.Run(async () => await LoadAttendanceRecordsAsync());
        }

        /// <summary>
        /// Loads attendance records from the API.
        /// </summary>
        private async Task LoadAttendanceRecordsAsync()
        {
            IsLoading = true;
            try
            {
                var records = await _apiService.GetAttendanceRecordsAsync();
                foreach (var record in records)
                {
                    AttendanceRecords.Add(record);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading attendance records: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}