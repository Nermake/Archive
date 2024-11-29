using System;

namespace Mori.SDK.ZoomCamera
{
    [Serializable]
    public class ZoomProperties
    {
        public float ZoomSpeed = 1;
        public float Smoothness = 1;
        public float ZoomMin = 3;
        public float ZoomMax = 10;
    }
}