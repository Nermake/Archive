using UnityEngine;

namespace Mori.SDK.Inventory.Items
{
    public interface IItem
    {
        public string ID { get; }
        public Sprite Icon { get; }
    }
}