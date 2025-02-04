using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    public class QuestImplementer : MonoBehaviour
    {
        [SerializeField] private QuestConfig _config;
        [SerializeField] private List<GoalImplementer> _goalImplementers;

        private Dictionary<string, GoalImplementer> _implementers = new Dictionary<string, GoalImplementer>();
        private Dictionary<string, Goal> _goals = new Dictionary<string, Goal>();
        
        private Quest _quest;
        
        public string ID => _config.ID;

        public void Init(Quest quest)
        {
            _quest = quest;
            
            foreach (var implementer in _goalImplementers)
            {
                _implementers.Add(implementer.ID, implementer);
                implementer.Implement += OnImplement;
            }

            foreach (var goal in _quest.Goals)
            {
                _goals.Add(goal.ID, goal);
            }
        }

        private void OnImplement(GoalImplementer implementer, int value)
        {
            var goal = _goals[implementer.ID];
            goal.SetAmount(value);

            if (goal.IsCompleted)
            {
                _goals.Remove(implementer.ID);
                implementer.Implement -= OnImplement;
            }
        }

        private void OnDestroy()
        {
            foreach (var implementer in _implementers)
            {
                implementer.Value.Implement -= OnImplement;
            }

            _implementers = null;
        }
    }
}