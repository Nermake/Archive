using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace QuestSystem
{
    public class QuestFrameView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _description;

        private string _task;
        private QuestConfig _config;
        
        public void SetQuestion(QuestConfig config)
        {
            _config = config;
            
            _title.text = config.Title;
            _task = string.Empty;
        }

        public void UpdateQuestFrame(List<Goal> goals)
        {
            _task = $"\t {_config.Description} \n \n Цели: \n";
            
            foreach (var goal in goals)
            {
                _task += $"\t {goal.Description} ({goal.CurrentAmount}/{goal.RequiredAmount}). \n";
            }

            _description.text = _task;
        }

        public void Clear() => _description.text = string.Empty;
        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);
    }
}