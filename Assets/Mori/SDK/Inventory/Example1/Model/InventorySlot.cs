using System;

namespace Mori.SDK.Inventory
{
    public class InventorySlot : IReadOnlyInventorySlot
    {
        
        public event Action<string> ItemIdChanged;
        public event Action<int> ItemAmountChanged;

        public string ItemId
        {
            get => _data.ItemId;
            set
            {
                if (_data.ItemId == value) return;
                
                _data.ItemId = value;
                ItemIdChanged?.Invoke(value);
            }
        }
        public int Amount
        {
            get => _data.Amount;
            set
            {
                if (_data.Amount == value) return;
                
                _data.Amount = value;
                ItemAmountChanged?.Invoke(value);
            }
        }

        public int Capacity { get; private set; }
        public bool IsEmpty => (Amount == 0 && string.IsNullOrEmpty(ItemId)) || Item == null;
        public bool IsFull => !IsEmpty && Amount == Capacity;
        public IReadOnlyInventoryItem Item { get; private set; }
        public Type ItemType => Item.Type;
        
        public void Clear()
        {
            if (IsEmpty) return;
            Item.State.Amount = 0;
            Item = null;
        }

        public void SetItem(IReadOnlyInventoryItem item)
        {
            if (IsEmpty) return;

            Item.State.Amount = 0;
        }

        private readonly InventorySlotData _data;

        public InventorySlot(InventorySlotData data) => _data = data;
    }
}