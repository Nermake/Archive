using System.Collections.Generic;
using UnityEngine;

namespace Mori.Patterns.StructuralPatterns.Services.Locator.Example
{
    public class MainScript : MonoBehaviour
    {
        private ServiceOne _one;
        private ServiceTwo _two;
        
        private List<IDisposable> _disposables = new List<IDisposable>();

        private void Awake()
        {
            _one = new ServiceOne();
            _two = new ServiceTwo();
            
            RegisterServices();
            Init();
            AddDisposables();
        }
        
        private void RegisterServices()
        {
            ServiceLocator.Initialize();
            
            ServiceLocator.Current.Register(_one);
            ServiceLocator.Current.Register(_two);
        }

        private void Init()
        {
            _two.Init();
            _one.Init(10, 20);
        }

        private void AddDisposables()
        {
            
        }

        private void OnDestroy()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}