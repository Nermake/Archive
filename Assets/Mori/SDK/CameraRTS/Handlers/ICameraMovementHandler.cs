using UnityEngine;

namespace Mori.SDK.CameraRTS.Handlers
{
    public interface ICameraMovementHandler
    {
        void Move(Vector3 inputDelta);
    }
}