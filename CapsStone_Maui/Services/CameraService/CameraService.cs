using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Maui.Essentials;


namespace CapsStone_Maui.Services
{
    public class CameraService
    {
        public async Task<Stream> CapturePhotoAsync()
        {
            var photo = await MediaPicker.CapturePhotoAsync();

            if (photo != null)
            {
                return await photo.OpenReadAsync();
            }

            return null;
        }
        private async Task InitializeMediaPicker()
        {
            if (!MediaPicker.IsCaptureSupported)
            {
                // Handle the case where capturing a photo is not supported
                throw new NotSupportedException("Capturing a photo is not supported on this device.");
            }

            if (!MediaPicker.IsCaptureSupported)
            {
                // Handle the case where picking a photo is not supported
                throw new NotSupportedException("Picking a photo is not supported on this device.");
            }

            // You can add additional initialization steps if needed
            // For example, requesting permissions
            await RequestCameraPermission();
        }

        private async Task RequestCameraPermission()
        {
            var status = await Permissions.RequestAsync<Permissions.Camera>();

            if (status != PermissionStatus.Granted)
            {
                // Handle the case where the camera permission is not granted
                throw new UnauthorizedAccessException("Camera permission is required to capture photos.");
            }
        }
    }

}
