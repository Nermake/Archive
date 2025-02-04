using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace QuestSystem
{
    public class Quest
    {
        public event Action<Quest, StateOfReadiness> ChangeState;
        public event Action<Quest, int, int> ChangeTime;
        
        public StateOfReadiness State { get; private set; }
        public bool IsTimer { get; private set; }
        public string ID { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ShortDescription { get; private set; }
        public float Time { get; private set; }

        public List<Goal> Goals { get; private set; }

        public void Init(QuestConfig config)
        {
            Goals = new List<Goal>();
            State = StateOfReadiness.InProgress;
            IsTimer = config.IsTimer;
            Time = config.Time;
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

            Time -= time;

            if (Time <= 0)
            {
                Time = 0;
                IsTimer = false;
                State = StateOfReadiness.Failed;
                ChangeState?.Invoke(this, StateOfReadiness.Failed);
                ChangeTime?.Invoke(this, 0, 0);
                
                return;
            }
            
            var minute = Mathf.RoundToInt(Time / 60);
            var second = Mathf.RoundToInt(Time % 60);
            ChangeTime?.Invoke(this, minute, second);
        }
        
        private void OnGoalCompleted()
        {
            IsTimer = false;
            
            var lenght = Goals.Count - 1;
            var count = Goals.Count(goal => goal.IsCompleted);
            
            if (count == lenght)
            {
                State = StateOfReadiness.Completed;
                ChangeState?.Invoke(this, State);
            }
        }
    }
}