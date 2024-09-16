using System.Collections.Generic;
using Interface;
using Interface.Inventory;
using Random = UnityEngine.Random;

namespace UI
{
    public class UIInventoryTester
    {
        public UIInventoryTester(ItemInfo swordInfo, ItemInfo appleInfo, UIInventorySlot[] uiSlots)
        {
            _swordInfo = swordInfo;
            _appleInfo = appleInfo;
            _uiSlots = uiSlots;

            inventory = new Inventory(15);
            inventory.OnInventoryStateChangedEvent += OnInventoryStateChanged;
        }
        
        private ItemInfo _swordInfo;
        private ItemInfo _appleInfo;
        private ItemInfo[] _items;
        private UIInventorySlot[] _uiSlots;

        public Inventory inventory { get; }

        public void FillSlots()
        {
            var allSlots = inventory.GetAllSlots();
            var availableSlots = new List<IInventorySlot>(allSlots);

            var filledSlots = 5;
            for (int i = 0; i < filledSlots; i++)
            {
                var filledSlot = AddRandomApple(availableSlots);
                availableSlots.Remove(filledSlot);

                filledSlot = AddRandomSword(availableSlots);
                availableSlots.Remove(filledSlot);
            }

            SetupInventoryUI(inventory);
        }
        
        private IInventorySlot AddRandomApple(List<IInventorySlot> slots)
        {
            var rSlotIndex = Random.Range(0, slots.Count);
            var rSlot = slots[rSlotIndex];
            var rCount = Random.Range(1, 4);
            //var apple = new ItemApple(_appleInfo);
            //apple.state.amount = rCount;
            //inventory.TryToAddToSlot(this, rSlot, apple);
            return rSlot;
        }

        private void SetupInventoryUI(Inventory inventory)
        {
            var allSlots = inventory.GetAllSlots();
            var allSlotsCount = allSlots.Length;
            for (int i = 0; i < allSlotsCount; i++)
            {
                var slot = allSlots[i];
                var uiSlot = _uiSlots[i];
                uiSlot.SetSlot(slot);
                uiSlot.Refresh();
            }
        }

        private IInventorySlot AddRandomSword(List<IInventorySlot> slots)
        {
            var rSlotIndex = Random.Range(0, slots.Count);
            var rSlot = slots[rSlotIndex];
            var rCount = Random.Range(1, 4);
            //var sword = new ItemSword(_swordInfo);
            //sword.state.amount = rCount;
            //inventory.TryToAddToSlot(this, rSlot, sword);
            return rSlot;
        }

        private void OnInventoryStateChanged(object sender)
        {
            foreach (var uiSlot in _uiSlots) uiSlot.Refresh();        
        }
    }
}