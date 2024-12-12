using System;
using Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Message;

namespace Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Processor
{
    public abstract class DebugProcessorBase : IDebugProcessor
    {
        private IDebugProcessor _next;

        public IDebugProcessor SetNext(IDebugProcessor processor)
        {
            return _next = processor ?? throw new ArgumentNullException(nameof(processor));
        }

        public virtual void Process(DebugMessageBase message) => _next?.Process(message);
    }
}