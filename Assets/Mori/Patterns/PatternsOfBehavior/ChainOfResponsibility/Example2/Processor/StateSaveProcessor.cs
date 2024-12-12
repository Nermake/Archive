using System;
using System.IO;
using Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Message;
using UnityEngine;

namespace Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Processor
{
    public class StateSaveProcessor : DebugProcessorBase
    {
        public override void Process(DebugMessageBase message)
        {
            if (message is StateSaveMessage stateMessage)
            {
                string filePath = $"{stateMessage.StateName}_state.json";
                
                try
                {
                    string json = JsonUtility.ToJson(stateMessage.StateData);
                    File.WriteAllText(filePath, json);
                    Debug.Log($"State Save Processor: State '{stateMessage.StateName}' saved to {filePath}");
                }
                catch (Exception e)
                {
                    Debug.LogError(
                        $"State Save Processor: Failed to save state '{stateMessage.StateName}'. Error: {e.Message}");
                    base.Process(message);
                }
            }
        }
    }
}