using TMPro;
using UnityEngine;

namespace Mori.SDK.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private InventoryItemView[] _items;
        [SerializeField] private TMP_Text _textOwner;

        public string OwnerId
        {
            get => _textOwner.text;
            set => _textOwner.text = value;
        }

        public InventoryItemView GetInventorySlotView(int index)
        {
            return _items[index];
        }
    }
}