using UnityEngine;

namespace Mori.SDK.CameraRTS.Handlers
{
    public class SmoothCameraMovementHandler : ICameraMovementHandler
    {
        private readonly CameraMovementProperties _properties;
        private Vector3 _cameraPosition;    
        
        public SmoothCameraMovementHandler(CameraMovementProperties properties)
        {
            _properties = properties;
            _cameraPosition = _properties.Pivot.position;
        }
        
        public void Move(Vector3 inputDelta)
        {
            _cameraPosition -= new Vector3(inputDelta.x, 0, inputDelta.y) * _properties.ZoomSpeed;

            _properties.Pivot.position = Vector3.Lerp(_properties.Pivot.position, _cameraPosition,
                Time.deltaTime / _properties.Smoothness);
        }
    }
}