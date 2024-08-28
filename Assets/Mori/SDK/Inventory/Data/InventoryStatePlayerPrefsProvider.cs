using System.Collections.Generic;
using UnityEngine;

namespace Mori.SDK.Inventory
{
    public class InventoryStatePlayerPrefsProvider : IInventoryStateProvider, IInventoryStateSaver
    {
        private const string KEY = "INVENTORY STATE";
        
        public InventoryStateData InventoryState { get; private set; }
        
        public void SaveInventoryState()
        {
            var json = JsonUtility.ToJson(InventoryState);
            PlayerPrefs.SetString(KEY, json);
        }

        public void LoadInventoryState()
        {
            if (PlayerPrefs.HasKey(KEY))
            {
                var json = PlayerPrefs.GetString(KEY);
                InventoryState = JsonUtility.FromJson<InventoryStateData>(json);
            }
            else
            {
                InventoryState = InitFromSettings();
                SaveInventoryState();
            }
        }

        private InventoryStateData InitFromSettings()
        {
            var inventoryState = new InventoryStateData
            {
                Inventories = new List<InventoryGridData>
                {
                    CreateTestInventory("Mori"),
                    CreateTestInventory("Nagumo")
                }
            };

            return inventoryState;
        }

        private InventoryGridData CreateTestInventory(string ownerId)
        {
            var size = new Vector2Int(3, 4);
            var createdInventorySlots = new List<InventorySlotData>();
            var length = size.x * size.y;

            for (int i = 0; i < length; i++)
            {
                createdInventorySlots.Add(new InventorySlotData());
            }
            
            var createdInventoryData = new InventoryGridData
            {
                OwnerId = ownerId,
                Size = size,
                Slots = createdInventorySlots
            };

            return createdInventoryData;
        }
    }
}