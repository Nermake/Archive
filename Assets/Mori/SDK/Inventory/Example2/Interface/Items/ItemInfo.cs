using System;

namespace Interface.Inventory
{
    public class ItemInfo : IInventoryItem
    {
        public IItemInfo info { get; }
        public IItemState state { get; }
        public Type type { get; }

        public IInventoryItem Clone()
        {
            var item = new ItemInfo();
            return item;
        }
    }
}