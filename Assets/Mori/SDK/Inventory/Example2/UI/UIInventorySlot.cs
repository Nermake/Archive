using Interface.Inventory;
using Interface.Inventory.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class UIInventorySlot : UISlot
    {
        [SerializeField] private UIInventoryItem _uiInventoryItem;

        private IInventorySlot _slot;

        private UIInventory _uiInventory;

        private void Awake()
        {
            _uiInventory = GetComponentInParent<UIInventory>();
        }

        public void SetSlot(IInventorySlot newSlot)
        {
            _slot = newSlot;
        }
  
        public override void OnDrop(PointerEventData eventData)
        {
            var otherItemUI = eventData.pointerDrag.GetComponent<UIInventoryItem>();
            var otherSlotUI = otherItemUI.GetComponentInParent<UIInventorySlot>();
            var otherSlot = otherSlotUI._slot;
            Inventory inventory = _uiInventory.inventory;

            inventory.DisplacementFromSlotToSlot(this, otherSlot, _slot);

            Refresh();
            otherSlotUI.Refresh();
        }

        public void Refresh()
        {
            if (_slot != null) _uiInventoryItem.Refresh(_slot);
        }
    }
}