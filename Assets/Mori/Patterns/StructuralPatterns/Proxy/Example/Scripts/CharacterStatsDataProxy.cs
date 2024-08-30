using System;
using UnityEngine;

namespace Mori.Patterns.StructuralPatterns.Proxy.Example
{
    public class CharacterStatsDataProxy : ICharacterStatsData
    {
        public event Action<int> HealthChanged;
        
        private readonly CharacterStatsData _origin;
        public int Health
        {
            get => _origin.Health;
            set
            {
                var newClampedHealth = Math.Max(value, 0);

                if (newClampedHealth != _origin.Health)
                {
                    _origin.Health = newClampedHealth;
                    HealthChanged?.Invoke(newClampedHealth);
                }
            }
        }
        
        public CharacterStatsDataProxy(CharacterStatsData origin)
        {
            _origin = origin;
        }
        
        public void DoSomething()
        {
            Debug.Log("CharacterStatsDataProxy: Start");
            
            _origin.DoSomething();
            
            Debug.Log("CharacterStatsDataProxy: End");
        }
    }
}