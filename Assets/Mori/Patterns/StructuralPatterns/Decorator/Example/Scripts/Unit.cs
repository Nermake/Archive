using System;

namespace Mori.Patterns.StructuralPatterns.Decorator.Example
{
    public class Unit : IStatsProvider
    {
        private readonly RaceType _race;

        public Unit(RaceType type)
        {
            _race = type;
        }

        public UnitStats GetStats()
        {
            switch (_race)
            {
                case RaceType.Orc:
                    return new UnitStats()
                    {
                        Strength = 15,
                        Agility = 7,
                        Intelligence = 3,
                        Stamina = 12
                    };
                
                case RaceType.Human:
                    return new UnitStats()
                    {
                        Strength = 10,
                        Agility = 9,
                        Intelligence = 8,
                        Stamina = 10
                    };
                
                case RaceType.Elf:
                    return new UnitStats()
                    {
                        Strength = 9,
                        Agility = 12,
                        Intelligence = 15,
                        Stamina = 7
                    };
                
                case RaceType.Troll:
                    return new UnitStats()
                    {
                        Strength = 12,
                        Agility = 12,
                        Intelligence = 4,
                        Stamina = 9
                    };
                
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum RaceType
    {
        Orc,
        Human,
        Elf,
        Troll
    }
}