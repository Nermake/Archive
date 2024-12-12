using System;
using System.IO;
using Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Message;
using UnityEngine;

namespace Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Processor
{
    public class FileLogProcessor : DebugProcessorBase
    {
        private readonly string _logFilePath;

        public FileLogProcessor(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public override void Process(DebugMessageBase message)
        {
            try
            {
                File.AppendAllText(_logFilePath, $"{DateTime.Now}: {message.Message}\n");
            }
            catch (Exception e)
            {
                Debug.LogError($"File Log Processor: Failed to write to log file. Error: {e.Message}-");
            }

            base.Process(message);
        }
    }
}