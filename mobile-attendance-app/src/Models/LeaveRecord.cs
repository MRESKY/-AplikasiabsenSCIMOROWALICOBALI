using System;
using Xunit;

namespace MobileAttendanceApp.Models
{
    /// <summary>
    /// Represents a leave record for a user.
    /// </summary>
    public class LeaveRecord
    {
        #nullable enable
        /// <summary>
        /// The ID of the user requesting leave.
        /// </summary>
        public string UserId { get; set; } = string.Empty;
        #nullable disable

        /// <summary>
        /// The start date of the leave.
        /// </summary>
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                if (value > EndDate)
                    throw new ArgumentException("StartDate tidak boleh lebih besar dari EndDate.");
                _startDate = value;
            }
        }
        private DateTime _startDate;

        /// <summary>
        /// The end date of the leave.
        /// </summary>
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                if (value < StartDate)
                    throw new ArgumentException("EndDate tidak boleh lebih kecil dari StartDate.");
                _endDate = value;
            }
        }
        private DateTime _endDate;

        #nullable enable
        /// <summary>
        /// The reason for the leave.
        /// </summary>
        public string Reason { get; set; } = string.Empty;
        #nullable disable

        /// <summary>
        /// Indicates whether the leave has been approved by an admin.
        /// </summary>
        public bool IsApproved { get; set; } = false; // Admin approval status

        /// <summary>
        /// Initializes a new instance of the LeaveRecord class.
        /// </summary>
        /// <param name="userId">The ID of the user requesting leave.</param>
        /// <param name="startDate">The start date of the leave.</param>
        /// <param name="endDate">The end date of the leave.</param>
        /// <param name="reason">The reason for the leave.</param>
        public LeaveRecord(string userId, DateTime startDate, DateTime endDate, string reason)
        {
            UserId = userId;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
            IsApproved = false;
        }
    }

    public class LeaveRecordTests
    {
        [Fact]
        public void StartDate_ShouldThrowException_WhenGreaterThanEndDate()
        {
            var leaveRecord = new LeaveRecord();
            Assert.Throws<ArgumentException>(() => leaveRecord.StartDate = DateTime.Now.AddDays(1));
        }
    }
}