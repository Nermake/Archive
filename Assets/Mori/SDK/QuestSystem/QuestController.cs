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
        
        private Dictionary<Quest, QuestView> _questViews = new();
        private readonly Dictionary<string, QuestImplementer> _implementers = new();

        private void Start()
        {
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
            var quest = new Quest();
            quest.Init(config);
            quest.ChangeState += OnQuestChangeState;
            quest.ChangeTime += OnQuestChangeTime;

            foreach (var goal in quest.Goals)
            {
                goal.ChangeAmount += OnGoalChangeAmount; 
            }
            
            var view = Instantiate(_prefab, _parent, true);
            view.SetQuestion(quest, config);
            view.PointerEnter += OpenQuestFrame;
            view.PointerExit += CloseQuestFrame;

            _implementers[config.ID].Init(quest);
            
            if (!quest.IsTimer) view.HideTimer();
            
            _questViews.Add(quest, view);
            
            OnQuestChangeState(quest, StateOfReadiness.InProgress);
        }

        private void OnQuestChangeTime(Quest sender, int minute, int second)
        {
            if (sender.IsTimer)
            {
                _questViews[sender].SetTimer(minute, second);
            }
        }

        private void OnQuestChangeState(Quest sender, StateOfReadiness stateOfReadiness)
        {
            var view = _questViews[sender];
            
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
                    foreach (var goal in sender.Goals)
                    {
                        goal.ChangeAmount -= OnGoalChangeAmount;
                    }
                    _implementers[sender.ID].Clear();
                    
                    break;
            }
        }

        private void OnGoalChangeAmount()
        {
            _questFrameView.Clear();
            _questFrameView.UpdateQuestFrame();
        }

        private void UpdateQuestTimers()
        {
            foreach (var quest in _questViews)
            {
                quest.Key.UpdateTimer(Time.deltaTime);
            }
        }

        private void OpenQuestFrame(QuestView view)
        {
            _questFrameView.Show();
            
            _questFrameView.SetQuestion(view.Config);
            _questFrameView.UpdateQuestFrame(view.Quest.Goals);
        }
        
        private void CloseQuestFrame(QuestView view)
        {
            _questFrameView.Hide();
        }

        public void ClearQuestList()
        {
            if (_questViews.Count == 0) return;
            
            foreach (var quest in _questViews)
            {
                quest.Key.ChangeState -= OnQuestChangeState;
                quest.Key.ChangeTime -= OnQuestChangeTime;

                Destroy(quest.Value.gameObject);
            }

            _questViews.Clear();
        }

        private void OnDestroy()
        {
            ClearQuestList();
        }
    }
}

