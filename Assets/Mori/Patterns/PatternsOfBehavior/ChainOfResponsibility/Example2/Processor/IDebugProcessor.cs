using Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Message;

namespace Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Processor
{
    public interface IDebugProcessor
    {
        public IDebugProcessor SetNext(IDebugProcessor processor);
        public void Process(DebugMessageBase message);
    }
}