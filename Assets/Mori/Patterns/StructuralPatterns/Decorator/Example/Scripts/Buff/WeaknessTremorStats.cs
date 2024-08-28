namespace Mori.Patterns.StructuralPatterns.Decorator.Example
{
    public class WeaknessTremorStats : StatsDecorator
    {
        public WeaknessTremorStats(IStatsProvider wrappedEntity) : base(wrappedEntity) { }

        protected override UnitStats GetStatsInternal()
        {
            var result = _wrappedEntity.GetStats();
            result.Strength *= 0.9f;
            result.Stamina *= 0.9f;

            return result;
        }
    }
}