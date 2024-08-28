using System;
using UnityEngine;

namespace Mori.Patterns.StructuralPatterns.Decorator.Example
{
    [Serializable]
    public struct UnitStats
    {
        [field : SerializeField] public float Strength { get; set; }
        [field : SerializeField] public float Agility { get; set; }
        [field : SerializeField] public float Intelligence { get; set; }
        [field : SerializeField] public float Stamina { get; set; }

        public static UnitStats operator +(UnitStats a, UnitStats b)
        {
            return new UnitStats()
            {
                Strength = a.Strength + b.Strength,
                Agility = a.Agility + b.Agility,
                Intelligence = a.Intelligence + b.Intelligence,
                Stamina = a.Stamina + b.Stamina
            };
        }
        
        public static UnitStats operator *(UnitStats a, float m)
        {
            return new UnitStats()
            {
                Strength = a.Strength * m,
                Agility = a.Agility * m,
                Intelligence = a.Intelligence * m,
                Stamina = a.Stamina * m
            };
        }
    }
}