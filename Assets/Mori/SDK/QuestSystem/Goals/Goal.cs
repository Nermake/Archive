using System;
using UnityEngine;

namespace QuestSystem
{
    public class Goal
    {
        public event Action Completed;
        public event Action ChangeAmount;
        
        public bool IsCompleted { get; private set; }
        public string ID { get; private set; }
        public string Description { get; private set; }
        public int CurrentAmount { get; private set; }
        public int RequiredAmount { get; private set; }

        public void Init(GoalConfig config)
        {
            IsCompleted = false;
            ID = config.ID;
            Description = config.Description;
            CurrentAmount = 0;
            RequiredAmount = config.RequiredAmount;
        }
        
        public void SetAmount(int value)
        {
            if (value <= 0) return;
            
            CurrentAmount = Mathf.Clamp(CurrentAmount + value, 0, RequiredAmount);
            
            ChangeAmount?.Invoke();
            CheckCompleted();
        }

        private void CheckCompleted()
        {
            if (CurrentAmount != RequiredAmount) return;
            
            Completed?.Invoke();
            IsCompleted = true;
        }
    }
}