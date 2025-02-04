using UnityEngine;

namespace QuestSystem
{
    [CreateAssetMenu(fileName = "GoalConfig", menuName = "Game/Goal Config", order = 0)]
    public class GoalConfig : ScriptableObject
    {
        [field: SerializeField, TextArea(5, 10)] public string Description { get; private set; }
        [field: SerializeField] public string ID { get; private set; }
        [field: SerializeField] public int RequiredAmount { get; private set; }
    }
}