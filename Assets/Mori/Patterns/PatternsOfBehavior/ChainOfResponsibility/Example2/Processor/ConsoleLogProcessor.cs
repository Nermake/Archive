using Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Message;
using UnityEngine;

namespace Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Processor
{
    public class ConsoleLogProcessor : DebugProcessorBase
    {
        public override void Process(DebugMessageBase message)
        {
            Debug.Log($"Console Log Processor: {message.Message}");
            base.Process(message);
        }
    }
}