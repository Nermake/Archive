using System;

namespace Mori.SDK.Inventory
{
    public class InventoryItem : IReadOnlyInventoryItem
    {
        public IItemInfo Item { get; }
        public IItemState State { get; }
        public Type Type { get; }
        
        public IReadOnlyInventoryItem Clone()
        {
            throw new NotImplementedException();
        }
    }
}