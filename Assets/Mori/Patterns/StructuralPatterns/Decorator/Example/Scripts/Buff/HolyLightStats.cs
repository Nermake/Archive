namespace Mori.Patterns.StructuralPatterns.Decorator.Example
{
    public class HolyLightStats : StatsDecorator
    {
        public HolyLightStats(IStatsProvider wrappedEntity) : base(wrappedEntity) { }

        protected override UnitStats GetStatsInternal()
        {
            return _wrappedEntity.GetStats() * 2;
        }
    }
}