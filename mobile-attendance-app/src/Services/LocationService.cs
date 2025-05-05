using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MobileAttendanceApp.Services
{
    public class LocationService
    {
        public async Task<Geolocation> GetCurrentLocationAsync()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    return new Geolocation
                    {
                        Latitude = location.Latitude,
                        Longitude = location.Longitude
                    };
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions such as permission denied or location unavailable
            }

            return null;
        }
    }

    public class Geolocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}