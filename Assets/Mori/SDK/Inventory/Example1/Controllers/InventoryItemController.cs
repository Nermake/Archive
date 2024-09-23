namespace Mori.SDK.Inventory
{
    public class InventoryItemController
    {
        private readonly InventoryItemView _view;
        
        public InventoryItemController(IReadOnlyInventoryItem item, InventoryItemView view)
        {
            _view = view;

            
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