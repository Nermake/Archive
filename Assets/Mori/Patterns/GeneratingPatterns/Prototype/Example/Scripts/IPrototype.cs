namespace Mori.Patterns.GeneratingPatterns.Prototype.Example
{
    public interface IPrototype<T>
    {
        public T Clone();
    }
}