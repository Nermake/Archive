using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mori.SDK.SaveSystem
{
    public class SaveLoadSystem : MonoBehaviour
    {
        [SerializeField] private GameData _gameData;
        
        private IDataService _dataService;
        
        public GameData GameData => _gameData;
        

        public void Init()
        {
            _dataService = new FileDataService(new JsonSerializer());
        }
        
        public void NewGame()
        {
            _gameData = new GameData 
            {
                Name = "Game",
                CurrentLevelName = "Demo"
            };
            SceneManager.LoadScene(_gameData.CurrentLevelName);
        }
        
        public void SaveGame() => _dataService.Save(_gameData);

        public void LoadGame(string gameName)
        {
            _gameData = _dataService.Load(gameName);

            if (String.IsNullOrWhiteSpace(_gameData.CurrentLevelName)) 
            {
                _gameData.CurrentLevelName = "Demo";
            }

            SceneManager.LoadScene(_gameData.CurrentLevelName);
        }
        
        public void ReloadGame() => LoadGame(_gameData.Name);

        public void DeleteGame(string gameName) => _dataService.Delete(gameName);
    }
}