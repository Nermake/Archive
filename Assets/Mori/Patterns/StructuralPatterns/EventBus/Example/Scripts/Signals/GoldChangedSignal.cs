namespace Mori.Patterns.StructuralPatterns.EventBus.Example.Signals
{
    public class GoldChangedSignal
    {
        public readonly int Gold;

        public GoldChangedSignal(int gold)
        {
            Gold = gold;
        }
    }
}