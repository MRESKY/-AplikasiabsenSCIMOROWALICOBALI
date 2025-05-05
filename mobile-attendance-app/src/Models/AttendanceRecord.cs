using System;

namespace MobileAttendanceApp.Models
{
    public class AttendanceRecord
    {
        public string UserId { get; set; }
        public DateTime Timestamp { get; set; }
        public string SelfieImage { get; set; }
        public Location Location { get; set; }
    }
}