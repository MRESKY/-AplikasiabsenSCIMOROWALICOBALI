using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MobileAttendanceApp.Services
{
    /// <summary>
    /// Service for retrieving the current location of the device.
    /// </summary>
    public class LocationService
    {
        /// <summary>
        /// Gets the current location of the device.
        /// </summary>
        /// <returns>
        /// A <see cref="Geolocation"/> object containing the latitude and longitude, or null if the location could not be retrieved.
        /// </returns>
        public async Task<Geolocation?> GetCurrentLocationAsync()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(10));
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    return new Geolocation
                    {
                        Latitude = location.Latitude,
                        Longitude = location.Longitude
                    };
                }
                else
                {
                    Console.WriteLine("Location data is null.");
                }
            }
            catch (FeatureNotSupportedException)
            {
                Console.WriteLine("Location is not supported on this device.");
            }
            catch (PermissionException)
            {
                Console.WriteLine("Permission to access location was denied.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            return null;
        }
    }

    /// <summary>
    /// Represents a geographical location with latitude and longitude.
    /// </summary>
    public class Geolocation
    {
        /// <summary>
        /// The latitude of the location.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// The longitude of the location.
        /// </summary>
        public double Longitude { get; set; }
    }
}