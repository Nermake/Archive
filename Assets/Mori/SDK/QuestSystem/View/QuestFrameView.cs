using TMPro;
using UnityEngine;

namespace QuestSystem
{
    public class QuestFrameView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _description;

        private string _message;
        private Quest _quest;
        
        public void SetQuestion(Quest quest)
        {
            _quest = quest;
            
            _title.text = quest.Title;
        }

        public void UpdateQuestFrame()
        {
            _message = $"\t {_quest.Description} \n \n Цели: \n";
            
            foreach (var goal in _quest.Goals)
            {
                _message += $"\t {goal.Description} ({goal.CurrentAmount}/{goal.RequiredAmount}). \n";
            }

            _description.text = _message;
        }

        public void Clear() => _description.text = string.Empty;
        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);
    }
}