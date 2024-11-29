using System;
using UnityEngine;

namespace Mori.SDK.CameraRTS
{
    [Serializable]
    public class CameraMovementProperties
    {
        public Transform Pivot;
        public float ZoomSpeed = 1;
        public float Smoothness = 0.2f;
    }
}