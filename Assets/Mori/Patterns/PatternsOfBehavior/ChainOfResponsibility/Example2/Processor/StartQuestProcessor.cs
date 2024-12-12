using System.Collections.Generic;
using Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Core;
using Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Message;
using UnityEngine;

namespace Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Processor
{
    public class StartQuestProcessor : QuestProcessorBase
    {
        public override void Process(QuestMessageBase message, Dictionary<SerializableGUID, Quest> quests)
        {
            Debug.Log($"{GetType().Name}: Processing message of type {message.GetType().Name}");

            if (message is StartQuestMessage startMessage && quests.TryGetValue(startMessage.QuestId, out var quest))
            {
                if (quest.State == QuestState.NotStarted)
                {
                    quest.State = QuestState.InProgress;
                    Debug.Log($"Quest '{quest.Name}' started.");
                }

                return;
            }

            base.Process(message, quests);
        }
    }
}