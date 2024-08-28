using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Mori.SDK.StorageService
{
    public class JsonToFileStorageService : IStorageService
    {
        private bool _isInProgressNow;
        
        public void Save(string key, object data, Action<bool> callback = null)
        {
            if (!_isInProgressNow)
            {
                SaveAsync(key, data, callback);
            }
            else
            {
                callback?.Invoke(false);
            }
        }
    
        public async void SaveAsync(string key, object data, Action<bool> callback)
        {
            string path = BuildPath(key);
            string json = JsonConvert.SerializeObject(data);
            await using (var fileStream = new StreamWriter(path))
            {
                await fileStream.WriteAsync(json);
            }
            
            callback?.Invoke(true);
        }
    
        public void Load<T>(string key, Action<T> callback)
        {
            if (key == null)
            {
                Debug.Log("Key = null");
                
                return;
            }
            
            string path = BuildPath(key);
            
            using (var fileStream = new StreamReader(path))
            {
                var json = fileStream.ReadToEnd();
                var data = JsonConvert.DeserializeObject<T>(json);
                
                callback.Invoke(data);
            }
        }

        private string BuildPath(string key)
        {
            return Path.Combine(Application.persistentDataPath, key);
        }
    }
}
