using UnityEditor;
using UnityEngine;

namespace Mori.SDK.GoogleImporter
{
    public class ConfigImportsMenu
    {
        private const string SPREADSHEET_ID = "1jctZANPvLel7QpvlJVnJw5VMGBE5moYqyI7AyBAKKvI";
        
        private const string ITEMS_SHEETS_NAME = "InventoryItems";
        private const string CREDENTIALS_PATH = "gamedevmori-3d6c01411944.json";
        private const string SETTINGS_FILE_NAME = "GameSettings";
        
        private const string ITEMS_SHEETS_NAME2 = "UnitLevels";
        private const string CREDENTIALS_PATH2 = "leoecs-ed0179a2aed7.json";
        private const string SETTINGS_FILE_NAME2 = "LevelSettings";

        [MenuItem("Mori/Import Items Settings")]
        private static async void LoadItemsSettings()
        {
            var sheetsImporter = new GoogleSheetsImporter(CREDENTIALS_PATH, SPREADSHEET_ID);
            var inventorySettings = LoadSettings();
            var itemsParser = new ItemSettingsParser(inventorySettings);
            
            await sheetsImporter.DownloadAndParseSheet(ITEMS_SHEETS_NAME, itemsParser);

            var jsonForSaving = JsonUtility.ToJson(inventorySettings);
            PlayerPrefs.SetString(SETTINGS_FILE_NAME, jsonForSaving);
            
            Debug.Log(jsonForSaving);
        }
        
        [MenuItem("Mori/Import Levels")]
        private static async void LoadItemsSettings2()
        {
            var sheetsImporter = new GoogleSheetsImporter(CREDENTIALS_PATH2, SPREADSHEET_ID);
            var gameSettings = LoadSettings();
            var levelParser = new LevelSettingsParser(gameSettings);
            
            await sheetsImporter.DownloadAndParseSheet(ITEMS_SHEETS_NAME2, levelParser);

            var jsonForSaving = JsonUtility.ToJson(gameSettings);
            PlayerPrefs.SetString(SETTINGS_FILE_NAME2, jsonForSaving);
            
            Debug.Log(jsonForSaving);
        }
        
        private static GameSettings LoadSettings()
        {
            var jsonLoaded = PlayerPrefs.GetString(SETTINGS_FILE_NAME);
            var gameSettings = !string.IsNullOrEmpty(jsonLoaded)
                ? JsonUtility.FromJson<GameSettings>(jsonLoaded)
                : new GameSettings();

            return gameSettings;
        }
    }
}