using System;

namespace Interface.Inventory
{
    public interface IInventorySlot
    {
        bool isFull { get; }
        bool isEmpty { get; }

        IInventoryItem item { get; }
        Type itemType { get; }
        int amount { get; }
        int capacity { get; }

        void Clear();
        void SetItem(IInventoryItem item);
    }
}