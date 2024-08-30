using UnityEngine;

namespace Mori.SDK.Zenject.Example.GameType
{
    public interface ICharacter
    {
        public void Move(Vector3 direction, float timeTick);
    }
}