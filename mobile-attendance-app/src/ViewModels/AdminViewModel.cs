using System.Collections.ObjectModel;
using System.Threading.Tasks;
using mobile-attendance-app.Models;
using mobile-attendance-app.Services;

namespace mobile-attendance-app.ViewModels
{
    public class AdminViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;
        public ObservableCollection<AttendanceRecord> AttendanceRecords { get; set; }

        public AdminViewModel()
        {
            _apiService = new ApiService();
            AttendanceRecords = new ObservableCollection<AttendanceRecord>();
            LoadAttendanceRecords();
        }

        private async void LoadAttendanceRecords()
        {
            var records = await _apiService.GetAttendanceRecordsAsync();
            foreach (var record in records)
            {
                AttendanceRecords.Add(record);
            }
        }
    }
}