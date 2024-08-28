using UnityEngine;

namespace Mori.Patterns.StructuralPatterns.Services.Locator.Example
{
    public class ServiceOne : IService
    {
        private int _x;
        private int _y;
        private ServiceTwo _serviceTwo;

        public void Init(int x, int y)
        {
            _serviceTwo = ServiceLocator.Current.Get<ServiceTwo>();
            
            _x = x;
            _y = y;
        }

        public void Move()
        {
            Debug.Log($"Move to {_x} : {_y} with a speed = {_serviceTwo.GetSpeed()}");
        }
    }
}