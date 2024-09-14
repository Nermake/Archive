using System.Collections.Generic;

namespace Mori.SDK.Inventory
{
    public class InventoryGridController
    {
        private readonly List<InventorySlotController> _slotControllers = new List<InventorySlotController>();
        
        public InventoryGridController(IReadOnlyInventoryGrid inventory, InventoryView view)
        {
            var size = inventory.Size;
            var slots = inventory.GetSlots();
            var lineLength = size.y;

            for (int i = 0; i < size.x; i++)
            {
                for (int j = 0; j < size.y; j++)
                {
                    var index = i * lineLength + j;
                    var slotView = view.GetInventorySlotView(index);
                    var slot = slots[i, j];
                    
                    _slotControllers.Add(new InventorySlotController(slot, slotView));
                }
            }

            view.OwnerId = inventory.OwnerId;
        }
    }
}