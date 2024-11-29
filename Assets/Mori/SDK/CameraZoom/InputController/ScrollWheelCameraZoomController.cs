using UnityEngine;

namespace Mori.SDK.ZoomCamera.InputControllers
{
    public class ScrollWheelCameraZoomController : CameraZoomController
    {
        protected override float ReadInputDelta()
        {
            return Input.GetAxis("Mouse ScrollWheel");
        }
    }
}