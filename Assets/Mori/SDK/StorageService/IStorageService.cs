using System;

namespace Mori.SDK.StorageService
{
     public interface IStorageService
     {
         void Save(string key, object data, Action<bool> callback = null);
         void SaveAsync(string key, object data, Action<bool> callback);
         void Load<T>(string key, Action<T> callback);
     }
}
