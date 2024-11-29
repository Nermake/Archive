using Mori.SDK.CameraRTS.Handlers;
using UnityEngine;

namespace Mori.SDK.CameraRTS.CameraInput
{
    [RequireComponent(typeof(Camera))]
    public class CustomMovementInput : CameraMovementInputBase
    {
        [SerializeField] private LayerMask _clickableMask;
        [SerializeField] private float _mouseSensitivity = 1;
        [SerializeField] private float _keyboardSensitivity = 1;
        
        private bool _dragEnabled;
        private Camera _camera;

        protected override void Awake()
        {
            base.Awake();

            _camera = GetComponent<Camera>();
        }
        
        protected override ICameraMovementHandler CreateMovementHandler()
        {
            return new SmoothCameraMovementHandler(_properties);
        }

        protected override Vector3 ReadInputDelta()
        {
            var mouseInputDelta = ReadMouseInputDelta();
            var keyboardInputDelta = ReadKeyboardInputDelta();

            return (mouseInputDelta + keyboardInputDelta) * _camera.fieldOfView;
        }

        private Vector3 ReadMouseInputDelta()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (IsClickedOnGround())
                {
                    _dragEnabled = true;
                }
                
                return Vector3.zero;
            }

            if (Input.GetMouseButtonUp(0))
            {
                _dragEnabled = false;
                return Vector3.zero;
            }

            if (_dragEnabled && Input.GetMouseButton(0))
            {
                return Input.mousePosition * _mouseSensitivity; //Input.mousePositionDelta
            }
            
            return Vector3.zero;
        }

        private Vector3 ReadKeyboardInputDelta()
        {
            var vertical = Input.GetAxis("Vertical");
            var horizontal = Input.GetAxis("Horizontal");

            return new Vector3(-horizontal, -vertical, 0) * _keyboardSensitivity;
        }

        private bool IsClickedOnGround()
        {
            var pointScreenPosition = Input.mousePosition;
            var ray = _camera.ScreenPointToRay(pointScreenPosition);
            var result = Physics.Raycast(ray, out _, float.MaxValue, _clickableMask.value);

            return result;
        }
    }
}