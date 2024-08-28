using System.IO;
using UnityEngine;

namespace Mori.SDK.BinaryStorage
{
    public class Storage
    {
        private string _filePath;
        private BuilderSelector _builderSelector;

        public Storage()
        {
            _builderSelector = new BuilderSelector();
            var directory = Application.persistentDataPath + "/saves";

            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
            
            _filePath = directory + "/GameSave.save";
        }

        public object Load(object saveDataByDefault)
        {
            if (!File.Exists(_filePath))
            {
                if (saveDataByDefault != null)
                {
                    Save(saveDataByDefault);
                }
                return saveDataByDefault;
            }

            var file = File.Open(_filePath, FileMode.Open);
            var savedData = _builderSelector.BinaryFormatter.Deserialize(file);
            file.Close();
            return savedData;
        }

        public void Save(object saveData)
        {
            var file = File.Create(_filePath);
            _builderSelector.BinaryFormatter.Serialize(file, saveData);
            file.Close();
        }
    }
}