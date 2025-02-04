using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    [CreateAssetMenu(fileName = "QuestConfig", menuName = "Game/Quest Config", order = 0)]
    public class QuestConfig : ScriptableObject
    {
        [field: SerializeField] public string ID { get; private set; }
        [field: SerializeField] public string Title { get; private set; }
        [field: SerializeField, TextArea(5, 10)] public string Description { get; private set; }
        [field: SerializeField, TextArea(2, 10)] public string ShortDescription { get; private set; }
        [field: SerializeField] public List<GoalConfig> GoalConfigs { get; private set; }
        
        [field: SerializeField] public bool IsTimer { get; private set; }
        [field: SerializeField] public float Time { get; private set; }
    }
}