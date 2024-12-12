using System.Collections.Generic;
using Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Core;
using Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Message;

namespace Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Processor
{
    public abstract class QuestProcessorBase : IQuestProcessor
    {
        private IQuestProcessor _next;

        public IQuestProcessor SetNext(IQuestProcessor processor) => _next = processor;

        public virtual void Process(QuestMessageBase message, Dictionary<SerializableGUID, Quest> quests) =>
            _next?.Process(message, quests);
    }
}