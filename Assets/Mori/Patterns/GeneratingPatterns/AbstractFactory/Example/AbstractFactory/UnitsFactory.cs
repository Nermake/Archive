namespace Mori.Patterns.AbstractFactory.Example
{
    public abstract class UnitsFactory
    {
        public abstract Knight CreateKnight();
        public abstract Mage CreateMage();
        public abstract Archer CreateArcher();
    }
}