using Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Core;
using Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Message;
using UnityEngine;

namespace Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.View
{
    public class QuestDemo : MonoBehaviour 
    {
        [SerializeField] private QuestManager questManager;

        void Start()
        {
            SerializableGUID questId = new();
            questManager.RegisterQuest(new Quest { Id = questId, Name = "Find the treasure" });
            
            questManager.UpdateQuest(new StartQuestMessage { QuestId = questId });
            questManager.UpdateQuest(new CompleteQuestMessage { QuestId = questId });
            questManager.UpdateQuest(new FailQuestMessage { QuestId = questId });
        }
    }
}