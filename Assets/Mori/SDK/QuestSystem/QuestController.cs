using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QuestSystem
{
    public class QuestController : MonoBehaviour
    {
        [Header("QuestList")]
        [SerializeField] private QuestView _prefab;
        [SerializeField] private RectTransform _parent;
        [SerializeField] private ScrollRect _scrollRectQuestList;
        
        [Space, Header("QuestFrame")]
        [SerializeField] private ScrollRect _scrollRectQuestFrame;
        [SerializeField] private QuestFrameView _questFrameView;
        
        [Space, Header("Others")]
        [SerializeField] private float _scrollSensitivity;
        [SerializeField] private List<QuestImplementer> _questImplementers;
        
        private Dictionary<string, Quest> _quests;
        private Dictionary<string, QuestView> _questViews;
        private Dictionary<string, QuestImplementer> _implementers;

        private void Start()
        {
            _quests = new Dictionary<string, Quest>();
            _questViews = new Dictionary<string, QuestView>();
            _implementers = new Dictionary<string, QuestImplementer>();
            
            _scrollRectQuestList.scrollSensitivity = _scrollSensitivity;
            _scrollRectQuestFrame.scrollSensitivity = _scrollSensitivity;

            foreach (var implementer in _questImplementers)
            {
                _implementers.Add(implementer.ID, implementer);
            }
        }

        private void Update()
        {
            if (_questViews != null) UpdateQuestTimers();
        }
        
        public void AddQuestion(QuestConfig config)
        {
            if (_quests.ContainsKey(config.ID)) return;
            
            var quest = new Quest();
            quest.Init(config);
            quest.ChangeState += OnQuestChangeState;
            quest.ChangeTime += OnQuestChangeTime;

            foreach (var goal in quest.Goals)
            {
                goal.ChangeAmount += OnGoalChangeAmount; 
            }
            
            var view = Instantiate(_prefab, _parent, true);
            view.SetQuestion(config);
            view.PointerEnter += OpenQuestFrame;
            view.PointerExit += CloseQuestFrame;

            _implementers[config.ID].Init(quest);
            
            if (!quest.IsTimer) view.HideTimer();
            
            _quests.Add(config.ID, quest);
            _questViews.Add(config.ID, view);
            
            OnQuestChangeState(quest.ID, StateOfReadiness.InProgress);
        }

        private void OnQuestChangeTime(string id, int minute, int second)
        {
            if (_quests[id].IsTimer)
            {
                _questViews[id].SetTimer(minute, second);
            }
        }

        private void OnQuestChangeState(string id, StateOfReadiness stateOfReadiness)
        {
            var view = _questViews[id];
            var quest = _quests[id];
            
            switch (stateOfReadiness)
            {
                case StateOfReadiness.InProgress:
                    view.SetState(Color.cyan);
                    
                    break;
                
                case StateOfReadiness.Completed:
                    view.SetState(Color.green);
                    view.HideTimer();
                    
                    break;
                
                case StateOfReadiness.Failed:
                    view.SetState(Color.red);
                    foreach (var goal in quest.Goals)
                    {
                        goal.ChangeAmount -= OnGoalChangeAmount;
                    }
                    _implementers[id].Clear();
                    
                    break;
            }
        }

        private void OnGoalChangeAmount()
        {
            _questFrameView.Clear();
            _questFrameView.UpdateQuestFrame();
        }

        private void OpenQuestFrame(string id)
        {
            _questFrameView.Show();
            
            _questFrameView.SetQuestion(_quests[id]);
            _questFrameView.UpdateQuestFrame();
        }
        
        private void CloseQuestFrame()
        {
            _questFrameView.Hide();
        }

        private void UpdateQuestTimers()
        {
            foreach (var quest in _quests)
            {
                quest.Value.UpdateTimer(Time.deltaTime);
            }
        }

        public void ClearQuestList()
        {
            if (_questViews.Count == 0) return;
            
            foreach (var quest in _quests)
            {
                quest.Value.ChangeState -= OnQuestChangeState;
                quest.Value.ChangeTime -= OnQuestChangeTime;
            }
            
            foreach (var view in _questViews)
            {
                view.Value.PointerEnter -= OpenQuestFrame;
                view.Value.PointerExit -= CloseQuestFrame;

                Destroy(view.Value.gameObject);
            }

            foreach (var implementer in _implementers)
            {
                implementer.Value.Clear();
            }

            _quests.Clear();
            _questViews.Clear();
        }

        private void OnDestroy() => ClearQuestList();
    }
}

