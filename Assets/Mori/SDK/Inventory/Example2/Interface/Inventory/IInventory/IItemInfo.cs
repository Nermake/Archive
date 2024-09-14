using UnityEngine;

namespace Interface.Inventory
{
    public interface IItemInfo
    {
        string id { get; }
        string title { get; }
        string description { get; }
        int maxItemsInInventorySlot { get; }
        Sprite spriteIcon { get; }
    }
}