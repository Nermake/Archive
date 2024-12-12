using Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Message;
using Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Processor;
using UnityEngine;

namespace Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.View
{
    public class DebugToolkit : MonoBehaviour
    {
        [SerializeField] string logFilePath = "debug_log.txt";

        private IDebugProcessor _chain;

        private void Awake()
        {
            _chain = new NullCheckProcessor();
            _chain.SetNext(new ConsoleLogProcessor())
                .SetNext(new FileLogProcessor(logFilePath))
                .SetNext(new StateSaveProcessor());
        }

        public void Log(DebugMessageBase message) => _chain.Process(message);
    }
}