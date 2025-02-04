using System;
using UnityEngine;

namespace QuestSystem
{
    public class GoalImplementer : MonoBehaviour
    {
        public event Action<GoalImplementer, int> Implement; 
        
        [SerializeField] private GoalConfig _config;

        public string ID => _config.ID;

        public void OnImplement(int value) => Implement?.Invoke(this, value);
    }
}