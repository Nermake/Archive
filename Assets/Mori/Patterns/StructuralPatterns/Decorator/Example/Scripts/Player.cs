using System.Collections.Generic;

namespace Mori.Patterns.StructuralPatterns.Decorator.Example
{
    public class Player
    {
        private RaceType _race = RaceType.Orc;
        private Specialization _specialization = Specialization.Warrior;
        private IStatsProvider _provider;

        public void Init()
        {
            _provider = new Unit(_race);
            _provider = new SpecializationStats(_provider, _specialization);
            _provider = new HolyLightStats(_provider);
            _provider = new CrippleIntelligenceStats(_provider);
        }

        public UnitStats GetStats() => _provider.GetStats();
    }
}