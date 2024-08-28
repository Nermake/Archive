namespace Mori.Patterns.StructuralPatterns.Decorator.Example
{
    public class ApplyOrcFrenzyStats : StatsDecorator
    {
        public ApplyOrcFrenzyStats(IStatsProvider wrappedEntity) : base(wrappedEntity) { }

        protected override UnitStats GetStatsInternal()
        {
            return _wrappedEntity.GetStats() + new Unit(RaceType.Orc).GetStats();
        }
    }
}