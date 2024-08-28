namespace Mori.Patterns.StructuralPatterns.Decorator.Example
{
    public class CrippleIntelligenceStats : StatsDecorator
    {
        public CrippleIntelligenceStats(IStatsProvider wrappedEntity) : base(wrappedEntity) { }

        protected override UnitStats GetStatsInternal()
        {
            var result = _wrappedEntity.GetStats();
            result.Intelligence = 0;

            return result;
        }
    }
}