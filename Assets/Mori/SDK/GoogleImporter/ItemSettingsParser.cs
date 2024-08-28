using System;
using System.Collections.Generic;

namespace Mori.SDK.GoogleImporter
{
    public class ItemSettingsParser : IGoogleSheetParser
    {
        private readonly InventorySettings _inventorySettings;
        private ItemSettings _currentItemSettings;

        public ItemSettingsParser(InventorySettings inventorySettings)
        {
            _inventorySettings = inventorySettings;
            _inventorySettings.Items = new List<ItemSettings>();
        }
        
        public void Parse(string header, string token)
        {
            switch (header)
            {
                case "ID":
                    _currentItemSettings = new ItemSettings
                    {
                        Id = token
                    };
                    _inventorySettings.Items.Add(_currentItemSettings);
                    
                    break;
                
                case "CellCapacity":
                    _currentItemSettings.CellCapacity = Convert.ToInt32(token);
                    
                    break;
                
                case "Title":
                    _currentItemSettings.Title = token;
                    
                    break;
                
                case "Description":
                    _currentItemSettings.Description = token;
                    
                    break;
                
                case "IconName":
                    _currentItemSettings.IconName = token;
                    
                    break;
                
                default:
                    throw new Exception($"Invalid header: {header} ");
            }
        }
    }
}