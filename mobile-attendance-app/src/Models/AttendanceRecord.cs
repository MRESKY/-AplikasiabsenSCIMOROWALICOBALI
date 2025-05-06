using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MobileAttendanceApp.Models
{
    #nullable enable
    /// <summary>
    /// Represents an attendance record for a user.
    /// </summary>
    public class AttendanceRecord
    {
        private string _userId;
        private string _selfieImage = string.Empty;
        private string _jobDescription = string.Empty;

        /// <summary>
        /// The ID of the user.
        /// </summary>
        public string UserId 
        { 
            get => _userId; 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(UserId), "UserId tidak boleh kosong.");
                _userId = value;
            }
        }

        /// <summary>
        /// The timestamp of the attendance.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The path or URL of the selfie image taken during attendance.
        /// </summary>
        public string SelfieImage
        {
            get => _selfieImage;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("SelfieImage tidak boleh kosong.");
                _selfieImage = value;
            }
        }

        /// <summary>
        /// Represents the location where the attendance was recorded.
        /// </summary>
        public Location Location { get; set; } = new Location();

        /// <summary>
        /// A descriptive text about the job the employee will perform.
        /// </summary>
        public string JobDescription
        {
            get => _jobDescription;
            set
            {
                if (value.Length > 500)
                    throw new ArgumentException("Deskripsi pekerjaan tidak boleh lebih dari 500 karakter.");
                _jobDescription = value;
            }
        }
    }
    #nullable disable

    public class Location
    {
        private double _latitude;
        private double _longitude;

        public double Latitude
        {
            get => _latitude;
            set
            {
                if (value < -90 || value > 90)
                    throw new ArgumentOutOfRangeException(nameof(Latitude), "Latitude harus antara -90 dan 90.");
                _latitude = value;
            }
        }

        public double Longitude
        {
            get => _longitude;
            set
            {
                if (value < -180 || value > 180)
                    throw new ArgumentOutOfRangeException(nameof(Longitude), "Longitude harus antara -180 dan 180.");
                _longitude = value;
            }
        }
    }

    public class LeaveCalendarViewModel : BaseViewModel
    {
        private readonly LeaveService _leaveService;

        public ObservableCollection<LeaveRecord> LeaveRecords { get; set; }

        public LeaveCalendarViewModel(LeaveService leaveService)
        {
            _leaveService = leaveService;
            LeaveRecords = new ObservableCollection<LeaveRecord>();
        }

        public async Task LoadLeaveRecordsAsync()
        {
            try
            {
                var records = await _leaveService.GetLeaveRecordsAsync();
                LeaveRecords.Clear();
                foreach (var record in records)
                {
                    LeaveRecords.Add(record);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading leave records: {ex.Message}");
                // Tampilkan pesan error ke pengguna jika diperlukan
            }
        }
    }
}

builder.Services.AddSingleton<HttpClient>();
builder.Services.AddSingleton<LeaveService>();
builder.Services.AddTransient<LeaveCalendarViewModel>();