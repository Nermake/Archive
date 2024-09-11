using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Mori.SDK.SaveSystem
{
    public class FileDataService : IDataService
    {
        private readonly ISerializer _serializer;
        private readonly string _dataPath;
        private readonly string _fileExtension;

        public FileDataService(ISerializer serializer)
        {
            _dataPath = Application.persistentDataPath;
            _fileExtension = "json";
            
            _serializer = serializer;
        }
        
        private string GetPathToFile(string fileName) 
        {
            return Path.Combine(_dataPath, string.Concat(fileName, ".", _fileExtension));
        }
        
        public void Save(GameData data, bool overWrite = true)
        {
            var fileLocation = GetPathToFile(data.Name);

            if (!overWrite && File.Exists(fileLocation)) 
            {
                throw new IOException($"The file '{data.Name}.{_fileExtension}' already exists and cannot be overwritten.");
            }

            File.WriteAllText(fileLocation, _serializer.Serialize(data));
        }

        public GameData Load(string name)
        {
            var fileLocation = GetPathToFile(name);

            if (!File.Exists(fileLocation))
            {
                throw new ArgumentException($"No persisted GameData with name '{name}'");
            }

            return _serializer.Deserialize<GameData>(File.ReadAllText(fileLocation));
        }

        public void Delete(string name) 
        {
            var fileLocation = GetPathToFile(name);

            if (File.Exists(fileLocation)) 
            {
                File.Delete(fileLocation);
            }
        }

        public void DeleteAll() 
        {
            foreach (var filePath in Directory.GetFiles(_dataPath))
            {
                File.Delete(filePath);
            }
        }

        public IEnumerable<string> ListSaves() 
        {
            foreach (var path in Directory.EnumerateFiles(_dataPath)) 
            {
                if (Path.GetExtension(path) == _fileExtension) 
                {
                    yield return Path.GetFileNameWithoutExtension(path);
                }
            }
        }
    }
}