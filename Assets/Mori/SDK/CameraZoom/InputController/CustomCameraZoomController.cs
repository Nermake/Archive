﻿using UnityEngine;

namespace Mori.SDK.ZoomCamera.InputControllers
{
    public class CustomCameraZoomController : CameraZoomController
    {
        [SerializeField] private float _verticalMultiplayer = 0.01f;
        
        protected override float ReadInputDelta()
        {
            return Input.GetAxis("Mouse ScrollWheel") + Input.GetAxis("Vertical") * _verticalMultiplayer;
        }
    }
}