namespace Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Message
{
    public abstract class DebugMessageBase
    {
        public string Message { get; }

        protected DebugMessageBase(string message) => Message = message;
    }
}