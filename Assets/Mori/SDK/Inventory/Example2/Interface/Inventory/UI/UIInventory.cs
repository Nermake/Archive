using UI;
using UnityEngine;

namespace Interface.Inventory.UI
{
    public class UIInventory : MonoBehaviour
    {
        [SerializeField] private ItemInfo _test1;
        [SerializeField] private ItemInfo _test2;
        
        private UIInventoryTester _tester;
        public Inventory inventory => _tester.inventory;

        private void Start()
        {
            var uiSlots = GetComponentsInChildren<UIInventorySlot>();
            _tester = new UIInventoryTester(_test1, _test2, uiSlots);
            _tester.FillSlots();
        }
    }
}