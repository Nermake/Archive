using System;

namespace Interface.Inventory
{
    public interface IInventoryItem
    {
        IItemInfo info { get; }
        IItemState state { get; }
        Type type { get; }

        IInventoryItem Clone();
    }
}