using Mori.SDK.Zenject.Example.GameType;
using UnityEngine;
using Zenject;

namespace Mori.SDK.Zenject.Example
{
    public class Tester : MonoBehaviour
    {
        private Unit2 _unit2;

        private void Start()
        {
            _unit2 = new Unit2();
            _unit2.Log();
        }
    }
}