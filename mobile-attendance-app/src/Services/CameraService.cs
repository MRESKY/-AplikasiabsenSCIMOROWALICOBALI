using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace MobileAttendanceApp.Services
{
    public class CameraService
    {
        public async Task<string> CapturePhotoAsync()
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
    }
}