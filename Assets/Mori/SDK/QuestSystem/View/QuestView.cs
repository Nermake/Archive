using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace QuestSystem
{
    public class QuestView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public event Action<QuestView> PointerEnter;
        public event Action<QuestView> PointerExit;
        
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private TimerView _view;
        [SerializeField] private Image _state;

        public QuestConfig Config { get; private set; }
        public Quest Quest { get; private set; }
        
        public void SetQuestion(Quest quest, QuestConfig config)
        {
            Quest = quest;
            Config = config;
            
            _title.text = config.Title;
            _description.text = config.ShortDescription;
        }
        public void SetTimer(int minute, int second) => _view.Timer.text = $"{minute}:{second}";
        public void SetState(Color color) => _state.color = color;
        public void ShowTimer() => _view.gameObject.SetActive(true);
        public void HideTimer() => _view.gameObject.SetActive(false);
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            PointerEnter?.Invoke(this);
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            PointerExit?.Invoke(this);
        }
    }
}