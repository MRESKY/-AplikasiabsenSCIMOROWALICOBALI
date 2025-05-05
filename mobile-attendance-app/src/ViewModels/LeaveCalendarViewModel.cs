using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using MobileAttendanceApp.Models;
using Newtonsoft.Json;

namespace MobileAttendanceApp.ViewModels
{
    /// <summary>
    /// ViewModel for managing leave records in the calendar.
    /// </summary>
    public class LeaveCalendarViewModel : BaseViewModel
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// The collection of leave records.
        /// </summary>
        public ObservableCollection<LeaveRecord> LeaveRecords { get; set; }

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
        /// Initializes a new instance of the <see cref="LeaveCalendarViewModel"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client for API communication.</param>
        public LeaveCalendarViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
            LeaveRecords = new ObservableCollection<LeaveRecord>();
        }

        /// <summary>
        /// Loads leave records from the API.
        /// </summary>
        public async Task LoadLeaveRecordsAsync()
        {
            IsLoading = true;
            try
            {
                var records = await GetLeaveRecordsAsync();
                LeaveRecords.Clear();
                foreach (var record in records)
                {
                    LeaveRecords.Add(record);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading leave records: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        /// <summary>
        /// Retrieves leave records from the API.
        /// </summary>
        /// <returns>A list of leave records.</returns>
        public async Task<List<LeaveRecord>> GetLeaveRecordsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/leave");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<LeaveRecord>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching leave records: {ex.Message}");
                return new List<LeaveRecord>();
            }
        }
    }
}

<Button Text="Kalender Cuti" Command="{Binding NavigateToLeaveCalendarCommand}" />