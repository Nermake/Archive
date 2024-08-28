using System;
using UnityEngine;

namespace Mori.Patterns.StructuralPatterns.Decorator.Example
{
    public class MainScript : MonoBehaviour
    {
        [SerializeField] private UnitStats _stats;
        private Player _player;

        private void Start()
        {
            _player = new Player();
            _player.Init();

            _stats = _player.GetStats();
        }
    }
}