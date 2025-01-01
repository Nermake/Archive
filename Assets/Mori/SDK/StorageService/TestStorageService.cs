using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Mori.SDK.StorageService
{
    public class TestStorageService : MonoBehaviour
    {
        private const string key = "test_save"; //C:/Users/[USER_NAME]/AppData/LocalLow/[COMPANY_NAME]/[GAME_NAME]
        private IStorageService _storageService;
        private TestStorageItem _item;
    
        private void Start()
        {
            _storageService = new JsonToFileStorageService();
            
            Debug.Log("KeyCode.Space = Create item \n" +
                      "KeyCode.T = Change data \n" +
                      "KeyCode.P = Data saved \n" +
                      "KeyCode.N = Data loaded \n" +
                      "KeyCode.L = Cleansing data \n");
        }
    
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Create default item.");
                 _item = new TestStorageItem
                 {
                     StringParameter = "test",
                     DictionaryParameter = new Dictionary<string, int> {{"par1", 20}, {"mob", 100}}
                 };
                 Debug.Log($"Start data, string: {_item.StringParameter}, " +
                           $"dictionary[0]: {_item.DictionaryParameter.Keys.ElementAt(0)}: {_item.DictionaryParameter.Values.ElementAt(0)} " +
                           $"dictionary[1]: {_item.DictionaryParameter.Keys.ElementAt(1)}: {_item.DictionaryParameter.Values.ElementAt(1)}");
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                _item.DictionaryParameter["par1"] += Random.Range(-50, 50);
                _item.DictionaryParameter["mob"] += Random.Range(-50, 50);
                
                Debug.Log($"Change data, string: {_item.StringParameter}, " +
                          $"dictionary[0]: {_item.DictionaryParameter.Keys.ElementAt(0)}: {_item.DictionaryParameter.Values.ElementAt(0)} " +
                          $"dictionary[1]: {_item.DictionaryParameter.Keys.ElementAt(1)}: {_item.DictionaryParameter.Values.ElementAt(1)}");
                
                
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                _storageService.Save(key, _item);
                                
                Debug.Log("Data saved successfully");
            }
            
            if (Input.GetKeyDown(KeyCode.N))
            {
                _storageService.Load<TestStorageItem>(key, data =>
                {
                    Debug.Log($"Loaded, string: {data.StringParameter}, " +
                              $"dictionary[0]: {data.DictionaryParameter.Keys.ElementAt(0)}: {data.DictionaryParameter.Values.ElementAt(0)} " +
                              $"dictionary[1]: {data.DictionaryParameter.Keys.ElementAt(1)}: {data.DictionaryParameter.Values.ElementAt(1)}");
                });
            }
            
            if (Input.GetKeyDown(KeyCode.N))
            {
                _storageService.Load<TestStorageItem>(key, Callback);
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                _item = null;
                _storageService.Save(key, _item);
                
                Debug.Log("Cleansing data");
            }
        }

        private void Callback(TestStorageItem obj)
        {
            throw new NotImplementedException();
        }

        private void OnGet()
        {
            
        }
    }
}






