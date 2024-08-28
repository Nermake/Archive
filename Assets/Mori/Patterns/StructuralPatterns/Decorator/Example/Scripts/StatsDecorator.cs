namespace Mori.Patterns.StructuralPatterns.Decorator.Example
{
    public abstract class StatsDecorator : IStatsProvider
    {
        protected readonly IStatsProvider _wrappedEntity;

        protected StatsDecorator(IStatsProvider wrappedEntity)
        {
            _wrappedEntity = wrappedEntity;
        }

        public UnitStats GetStats() => GetStatsInternal();

        protected abstract UnitStats GetStatsInternal();
    }
}