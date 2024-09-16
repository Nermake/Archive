namespace Mori.SDK.Inventory
{
    public class InventorySlotController
    {
        private readonly InventoryItemView _view;
        
        public InventorySlotController(IReadOnlyInventorySlot slot, InventoryItemView view)
        {
            _view = view;

            slot.ItemIdChanged += OnSlotItemIdChanged;
            slot.ItemAmountChanged += OnSlotItemAmountChanged;

            view.Title = slot.ItemId;
            view.Amount = slot.Amount;
        }
        
        private void OnSlotItemIdChanged(string newItemId)
        {
            _view.Title = newItemId;
        }
        
        private void OnSlotItemAmountChanged(int newAmount)
        {
            _view.Amount = newAmount;
        }
    }
}