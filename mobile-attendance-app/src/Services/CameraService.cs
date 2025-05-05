using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace MobileAttendanceApp.Services
{
    /// <summary>
    /// Service for capturing photos using the device's camera.
    /// </summary>
    public class CameraService
    {
        /// <summary>
        /// Captures a photo using the device's camera and saves it to the cache directory.
        /// </summary>
        /// <returns>
        /// The file path of the captured photo, or null if the operation was canceled or failed.
        /// </returns>
        public async Task<string?> CapturePhotoAsync()
        {
            if (!MediaPicker.IsCaptureSupported)
            {
                Console.WriteLine("Capture photo is not supported on this device.");
                return null;
            }

            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                var stream = await photo.OpenReadAsync();
                var filePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await stream.CopyToAsync(fileStream);
                }

                return filePath;
            }
            catch (FeatureNotSupportedException)
            {
                Console.WriteLine("This feature is not supported on the device.");
            }
            catch (PermissionException)
            {
                Console.WriteLine("Permission to access the camera was denied.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            return null;
        }
    }
}

<uses-permission android:name="android.permission.CAMERA" />
<key>NSCameraUsageDescription</key>
<string>App needs access to the camera to capture photos.</string>