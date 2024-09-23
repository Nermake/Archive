using System;

namespace Mori.SDK.Inventory
{
    public interface IReadOnlyInventorySlot
    {
        event Action<string> ItemIdChanged;
        event Action<int> ItemAmountChanged;
        
        string ItemId { get; } // todo, swap with SetItem()
        int Amount { get; }
        int Capacity { get; }
        bool IsEmpty { get; }
        bool IsFull { get; }
        IReadOnlyInventoryItem Item { get; }
        Type ItemType { get; }

        void Clear();
        void SetItem(IReadOnlyInventoryItem item);
    }
}