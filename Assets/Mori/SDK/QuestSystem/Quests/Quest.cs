using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace QuestSystem
{
    public class Quest
    {
        public event Action<string, StateOfReadiness> ChangeState;
        public event Action<string, int, int> ChangeTime;

        private StateOfReadiness _state;
        private float _time;
        
        public bool IsTimer { get; private set; }
        public string ID { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ShortDescription { get; private set; }
        public List<Goal> Goals { get; private set; }

        public void Init(QuestConfig config)
        {
            Goals = new List<Goal>();
            
            _state = StateOfReadiness.InProgress;
            _time = config.Time;
            
            ID = config.ID;
            IsTimer = config.IsTimer;
            Title = config.Title;
            Description = config.Description;
            ShortDescription = config.ShortDescription;

            foreach (var goalConfig in config.GoalConfigs)
            {
                var goal = new Goal();
                
                goal.Init(goalConfig);
                goal.Completed += OnGoalCompleted;
                
                Goals.Add(goal);
            }
        }

        public void UpdateTimer(float time)
        {
            if (!IsTimer) return;

            _time -= time;

            if (_time <= 0)
            {
                _time = 0;
                _state = StateOfReadiness.Failed;
                
                IsTimer = false;
                ChangeState?.Invoke(ID, StateOfReadiness.Failed);
                ChangeTime?.Invoke(ID, 0, 0);
                
                return;
            }
            
            var minute = Mathf.RoundToInt(_time / 60);
            var second = Mathf.RoundToInt(_time % 60);
            ChangeTime?.Invoke(ID, minute, second);
        }
        
        private void OnGoalCompleted()
        {
            var lenght = Goals.Count - 1;
            var count = Goals.Count(goal => goal.IsCompleted);
            
            if (count == lenght)
            {
                IsTimer = false;
       
                _state = StateOfReadiness.Completed;
                ChangeState?.Invoke(ID, _state);
            }
        }
    }
}