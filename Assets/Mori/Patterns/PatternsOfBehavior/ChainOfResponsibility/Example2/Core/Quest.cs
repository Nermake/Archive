using System;

namespace Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Core
{
    [Serializable]
    public class Quest
    {
        public SerializableGUID Id;
        public string Name;
        public QuestState State = QuestState.NotStarted;
    }
}