using System.Collections.Generic;
using Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Core;
using Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Message;
using UnityEngine;

namespace Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Processor
{
    public class FailQuestProcessor : QuestProcessorBase
    {
        public override void Process(QuestMessageBase message, Dictionary<SerializableGUID, Quest> quests)
        {
            Debug.Log($"{GetType().Name}: Processing message of type {message.GetType().Name}");
            if (message is FailQuestMessage failMessage && quests.TryGetValue(failMessage.QuestId, out var quest))
            {
                if (quest.State == QuestState.InProgress)
                {
                    quest.State = QuestState.Failed;
                    Debug.Log($"Quest '{quest.Name}' failed.");
                }

                return;
            }
            
            base.Process(message, quests);
        }
    }
}