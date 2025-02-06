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

            if (_implementers.Count == 0) //todo 1
            {
                foreach (var implementer in _goalImplementers)
                {
                    _implementers.Add(implementer.ID, implementer);
                    implementer.Implement += OnImplement;
                }
            }

            if (_goals.Count == 0) //todo 1
            {
                foreach (var goal in _quest.Goals)
                {
                    _goals.Add(goal.ID, goal);
                }
            }
        }

        private void OnImplement(GoalImplementer implementer, int value)
        {
            var goal = _goals[implementer.ID];
            goal.SetAmount(value);

            if (goal.IsCompleted)
            {
                implementer.Implement -= OnImplement;
                _goals.Remove(implementer.ID);
            }
        }

        public void Complete() //todo 1
        {
            _implementers.Clear();
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