using System.Collections.Generic;
using Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Core;
using Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Message;
using Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Processor;
using UnityEngine;

namespace Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.View
{
    public class QuestManager : MonoBehaviour
    {
        private Dictionary<SerializableGUID, Quest> _quests = new ();
        private IQuestProcessor _chain;

        void Awake()
        {
            _chain = new StartQuestProcessor();
            _chain.SetNext(new CompleteQuestProcessor())
                .SetNext(new FailQuestProcessor());
        }

        public void RegisterQuest(Quest quest) => _quests.Add(quest.Id, quest);
        public void UpdateQuest(QuestMessageBase message) => _chain.Process(message, _quests);
    }
}