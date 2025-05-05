using System;

namespace MobileAttendanceApp.Models
{
    #nullable enable
    /// <summary>
    /// Represents an attendance record for a user.
    /// </summary>
    public class AttendanceRecord
    {
        private string _userId;

        /// <summary>
        /// The ID of the user.
        /// </summary>
        public string UserId 
        { 
            get => _userId; 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("UserId tidak boleh kosong.");
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
        public string SelfieImage { get; set; } = string.Empty;

        /// <summary>
        /// The location where the attendance was recorded.
        /// </summary>
        public Location Location { get; set; } = new Location();

        /// <summary>
        /// A descriptive text about the job the employee will perform.
        /// </summary>
        public string JobDescription { get; set; } = string.Empty;
    }
    #nullable disable

    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}