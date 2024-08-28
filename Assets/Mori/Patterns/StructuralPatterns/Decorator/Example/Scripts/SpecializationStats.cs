using System;

namespace Mori.Patterns.StructuralPatterns.Decorator.Example
{
    public class SpecializationStats : StatsDecorator
    {
        private readonly Specialization _specialization;
        
        public SpecializationStats(IStatsProvider wrappedEntity, Specialization specialization) : base(wrappedEntity)
        {
            _specialization = specialization;
        }

        protected override UnitStats GetStatsInternal()
        {
            return _wrappedEntity.GetStats() + GetSpecializationStats(_specialization);
        }

        private UnitStats GetSpecializationStats(Specialization specialization)
        {
            switch (specialization)
            {
                case Specialization.Warrior:
                    return new UnitStats()
                    {
                        Strength = 10,
                        Agility = 6,
                        Intelligence = 4,
                        Stamina = 8
                    };
                
                case Specialization.Mage:
                    return new UnitStats()
                    {
                        Strength = 4,
                        Agility = 6,
                        Intelligence = 12,
                        Stamina = 6
                    };
                
                case Specialization.Rogue:
                    return new UnitStats()
                    {
                        Strength = 8,
                        Agility = 12,
                        Intelligence = 5,
                        Stamina = 8
                    };
                
                case Specialization.Hunter:
                    return new UnitStats()
                    {
                        Strength = 7,
                        Agility = 13,
                        Intelligence = 5,
                        Stamina = 10
                    };
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(specialization), specialization, null);
            }
        }
    }

    public enum Specialization
    {
        Warrior,
        Mage,
        Rogue,
        Hunter
    }
}