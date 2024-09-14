using Interface.Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIInventoryItem : UIItem
    {
        [SerializeField] private Image _imageIcon;
        [SerializeField] private Text _textAmount;

        private IInventoryItem _item;
    
        public void Refresh(IInventorySlot slot)
        {
            if (slot.isEmpty)
            {
                Cleanup();
                return;
            }

            _item = slot.item;
            _imageIcon.sprite = _item.info.spriteIcon;
            _imageIcon.gameObject.SetActive(true);

            bool textAmountEnabled = slot.amount > 1;
            _textAmount.gameObject.SetActive(textAmountEnabled);

            if (textAmountEnabled) _textAmount.text = $"x{slot.amount.ToString()}";
        }

        private void Cleanup()
        {
            _textAmount.gameObject.SetActive(false);
            _imageIcon.gameObject.SetActive(false);
        }
    }
}