using System;
using UnityEngine;

namespace Mori.Patterns.StructuralPatterns.Services.Locator.Example
{
    public class Test : MonoBehaviour
    {
        private ServiceOne _one;

        private void Start()
        {
            _one = ServiceLocator.Current.Get<ServiceOne>();
            
            Debug.Log("Press on button < Q >");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q)) _one.Move();
        }
    }
}