using System;
using System.Collections.Generic;

namespace Mori.SDK.GoogleImporter
{
    public class LevelSettingsParser : IGoogleSheetParser
    {
        private readonly GameSettings _gameSettings;
        private LevelSettings _levelSettings;

        public LevelSettingsParser(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            _gameSettings.Levels = new List<LevelSettings>();
        }
        
        public void Parse(string header, string token)
        {
            switch (header)
            {
                case "Level":
                    _levelSettings = new LevelSettings
                    {
                        Level = Convert.ToInt32(token)
                    };
                    _gameSettings.Levels.Add(_levelSettings);
                    
                    break;
                
                case "Exp":
                    _levelSettings.Exp = Convert.ToInt32(token);
                    
                    break;
                
                case "Add": break;
                
                case "Modificator": break;
                
                default:
                    throw new Exception($"Invalid header: {header} ");
            }
        }
    }
}