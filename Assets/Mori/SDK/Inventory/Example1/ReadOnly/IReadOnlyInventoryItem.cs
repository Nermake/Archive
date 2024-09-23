using System;

namespace Mori.SDK.Inventory
{
    public interface IReadOnlyInventoryItem
    {
        IItemInfo Item { get; }
        IItemState State { get; }
        Type Type { get; }

        IReadOnlyInventoryItem Clone();
    }
}