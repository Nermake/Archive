using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Mori.Patterns.DesignPattern.ObjectPool.Example
{
    public class PoolMono<T> where T : MonoBehaviour
    {
        private T _prefab;
        private List<T> pool;
        private bool _autoExpand;

        public PoolMono(T prefab, int count, bool autoExpand)
        {
            _prefab = prefab;
            _autoExpand = autoExpand;
            
            CreatePool(count);
        }
        
        private void CreatePool(int count)
        {
            pool = new List<T>();

            for (int i = 0; i < count; i++)
            {
                CreateObject();
            }
        }

        private T CreateObject(bool isActiveBeDefault = false)
        {
            var createdObject = Object.Instantiate(_prefab);
            createdObject.gameObject.SetActive(isActiveBeDefault);
            
            pool.Add(createdObject);

            return createdObject;
        }

        public bool HasFreeElement(out T element)
        {
            foreach (var mono in pool)
            {
                if (!mono.gameObject.activeInHierarchy)
                {
                    element = mono;
                    mono.gameObject.SetActive(true);

                    return true;
                }
            }

            element = null;
            return false;
        }

        public T GetFreeElement()
        {
            if (HasFreeElement(out var element)) return element;
            if (_autoExpand) return CreateObject(true);
            
            throw new Exception($"There is no free element in pool of type {typeof(T)}");
        }
    }
}