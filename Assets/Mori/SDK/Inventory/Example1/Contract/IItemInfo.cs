using UnityEngine;

namespace Mori.SDK.Inventory
{
    public interface IItemInfo
    {
        string ID { get; }
        string Title { get; }
        string Description { get; }
        int MaxItemsInInventorySlot { get; }
        Sprite Icon { get; }
    }
}