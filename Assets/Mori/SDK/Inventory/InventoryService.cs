using System.Collections.Generic;
using UnityEngine;

namespace Mori.SDK.Inventory
{
    public class InventoryService
    {
        private readonly IInventoryStateSaver _inventoryStateSaver;
        private readonly Dictionary<string, InventoryGrid> _inventoriesMap = new Dictionary<string, InventoryGrid>();

        public InventoryService(IInventoryStateSaver inventoryStateSaver)
        {
            _inventoryStateSaver = inventoryStateSaver;
        }
        
        public InventoryGrid RegisterInventory(InventoryGridData inventoryGridData)
        {
            var inventory = new InventoryGrid(inventoryGridData);
            _inventoriesMap[inventory.OwnerId] = inventory;

            return inventory;
        }

        public AddItemsToInventoryGridResult AddItemsToInventory(string ownerId, string itemId, int amount = 1)
        {
            var inventory = _inventoriesMap[ownerId];
            var result = inventory.AddItems(itemId, amount);
            
            _inventoryStateSaver.SaveInventoryState();

            return result;
        }
        
        public AddItemsToInventoryGridResult AddItemsToInventory(Vector2Int slotCoords, string ownerId, string itemId, int amount = 1)
        {
            var inventory = _inventoriesMap[ownerId];
            var result = inventory.AddItems(slotCoords, itemId, amount);

            _inventoryStateSaver.SaveInventoryState();
            
            return result;
        }

        public RemoveItemsFromInventoryGridResult RemoveItems(string ownerId, string itemId, int amount = 1)
        {
            var inventory = _inventoriesMap[ownerId];
            var result = inventory.RemoveItems(itemId, amount);
            
            _inventoryStateSaver.SaveInventoryState();
            
            return result;
        }

        public RemoveItemsFromInventoryGridResult RemoveItemsFromSlot(Vector2Int slotCoords, string ownerId, string itemId, int amount = 1)
        {
            var inventory = _inventoriesMap[ownerId];
            var result = inventory.RemoveItems(slotCoords, itemId, amount);
            
            _inventoryStateSaver.SaveInventoryState();
            
            return result;
        }

        public bool Has(string ownerId, string itemId, int amount = 1)
        {
            var inventory = _inventoriesMap[ownerId];

            return inventory.Has(itemId, amount);
        }

        public IReadOnlyInventoryGrid GetInventory(string ownerId) => _inventoriesMap[ownerId];
    }
}