using System;

namespace MobileAttendanceApp.Models
{
    /// <summary>
    /// Represents a geographical location with latitude and longitude.
    /// </summary>
    public class Location
    {
        private double _latitude;
        private double _longitude;

        /// <summary>
        /// The latitude of the location. Must be between -90 and 90.
        /// </summary>
        public double Latitude
        {
            get => _latitude;
            set
            {
                if (value < -90 || value > 90)
                    throw new ArgumentOutOfRangeException(nameof(Latitude), "Latitude must be between -90 and 90.");
                _latitude = value;
            }
        }

        /// <summary>
        /// The longitude of the location. Must be between -180 and 180.
        /// </summary>
        public double Longitude
        {
            get => _longitude;
            set
            {
                if (value < -180 || value > 180)
                    throw new ArgumentOutOfRangeException(nameof(Longitude), "Longitude must be between -180 and 180.");
                _longitude = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        public Location() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class with specified latitude and longitude.
        /// </summary>
        /// <param name="latitude">The latitude of the location.</param>
        /// <param name="longitude">The longitude of the location.</param>
        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Returns a string representation of the location.
        /// </summary>
        /// <returns>A string in the format "Latitude: {Latitude}, Longitude: {Longitude}".</returns>
        public override string ToString()
        {
            return $"Latitude: {Latitude}, Longitude: {Longitude}";
        }
    }
}

[Fact]
public void Latitude_ShouldThrowException_WhenOutOfRange()
{
    var location = new Location();
    Assert.Throws<ArgumentOutOfRangeException>(() => location.Latitude = 100);
}

[Fact]
public void Longitude_ShouldThrowException_WhenOutOfRange()
{
    var location = new Location();
    Assert.Throws<ArgumentOutOfRangeException>(() => location.Longitude = 200);
}