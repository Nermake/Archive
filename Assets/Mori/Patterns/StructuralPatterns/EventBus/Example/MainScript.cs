using Mori.Patterns.StructuralPatterns.EventBus.Example.Signals;
using UnityEngine;

namespace Mori.Patterns.StructuralPatterns.EventBus.Example
{
    public class MainScript : MonoBehaviour
    {
        private EventBus _eventBus;
        private int _gold;

        private void Start()
        {
            _eventBus = new EventBus();
            
            _eventBus.Subscribe<AddGoldSignal>(OnAddGold);
            _eventBus.Subscribe<GoldChangedSignal>(OnGoldChanged);
            _eventBus.Subscribe<SpendGoldSignal>(OnSpendGold);

            _gold = 100;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                var addGold = 10;
                
                _gold += addGold;
                _eventBus.Invoke(new AddGoldSignal(addGold));
                _eventBus.Invoke(new GoldChangedSignal(_gold));
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                var spendGold = 5;
                
                _gold -= spendGold;
                _eventBus.Invoke(new SpendGoldSignal(spendGold));
                _eventBus.Invoke(new GoldChangedSignal(_gold));
            }
        }

        private void OnAddGold(AddGoldSignal signal)
        {
            Debug.Log("Add Gold: " + signal.Value);
        }
        
        private void OnGoldChanged(GoldChangedSignal signal)
        {
            Debug.Log("Gold Changed: " + signal.Gold);
        }
        
        private void OnSpendGold(SpendGoldSignal signal)
        {
            Debug.Log("Spend Gold: " + signal.Value);
        }
    }
}