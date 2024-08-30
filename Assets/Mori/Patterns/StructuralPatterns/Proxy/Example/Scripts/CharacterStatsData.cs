using System;
using UnityEngine;

namespace Mori.Patterns.StructuralPatterns.Proxy.Example
{
    [Serializable]
    public class CharacterStatsData : ICharacterStatsData
    {
        [SerializeField] private int _health;

        public int Health { get => _health; set => _health = value; }

        public void DoSomething()
        {
            Debug.Log("CharacterStatsData: " + _health);
        }
    }
}