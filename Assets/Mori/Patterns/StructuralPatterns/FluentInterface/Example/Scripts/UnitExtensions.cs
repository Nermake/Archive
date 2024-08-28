using UnityEngine;

namespace Mori.Patterns.StructuralPatterns.FluentInterface.Example
{
    public static class UnitExtensions
    {
        public static Unit SetName(this Unit unit, string name)
        {
            unit.Name = name;

            return unit;
        }
        
        public static Unit SetDescription(this Unit unit, string description)
        {
            unit.Description = description;

            return unit;
        }
        
        public static Unit SetBaseDamage(this Unit unit, int baseDamage, UnitsMainConfig config)
        {
            var clampedDamage = Mathf.Clamp(baseDamage, 0, config.DamageMax);
            
            unit.BaseDamage = clampedDamage;

            return unit;
        }

        public static Unit WithWeapon(this Unit unit, Weapon weapon)
        {
            unit.Weapon = weapon;

            return unit;
        }
    }
}