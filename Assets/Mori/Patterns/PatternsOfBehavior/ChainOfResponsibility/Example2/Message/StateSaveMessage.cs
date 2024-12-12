namespace Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Message
{
    public class StateSaveMessage : DebugMessageBase
    {
        public string StateName { get; }
        public string StateData { get; }
        
        public StateSaveMessage(string stateName, string stateData) : base($"Save State: {stateName}")
        {
            StateName = stateName;
            StateData = stateData;
        }
    }
}