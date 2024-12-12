using System.Collections.Generic;
using Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Core;
using Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Message;

namespace Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Processor
{
    public interface IQuestProcessor
    {
        IQuestProcessor SetNext(IQuestProcessor processor);
        void Process(QuestMessageBase message, Dictionary<SerializableGUID, Quest> quests);
    }
}