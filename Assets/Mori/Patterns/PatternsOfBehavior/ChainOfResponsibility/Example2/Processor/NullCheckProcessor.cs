using Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Message;
using UnityEngine;

namespace Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Processor
{
    public class NullCheckProcessor : DebugProcessorBase
    {
        public override void Process(DebugMessageBase message)
        {
            if (message == null || message.Message == null)
            {
                Debug.LogError("NullCheckProcessor: Null message detected!");
                return;
            }

            base.Process(message);
        }
    }
}