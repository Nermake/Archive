using System;
using UnityEngine;

namespace Mori.Patterns.GeneratingPatterns.Builder.Example1
{
    public class MainScript : MonoBehaviour
    {
        private Factory _factory;
        private BmwCarBuilder _bmwCarBuilder;
        private PorscheCarBuilder _porscheCarBuilder;
        private ToyotaCarBuilder _toyotaCarBuilder;
        private Car[] cars;
        
        private void Start()
        {
            InitBuilders();
            CreatingCars();

            Output();
        }

        private void InitBuilders()
        {
            _factory = new Factory();
            _bmwCarBuilder = new BmwCarBuilder();
            _porscheCarBuilder = new PorscheCarBuilder();
            _toyotaCarBuilder = new ToyotaCarBuilder();
        }
        
        private void CreatingCars()
        {
            var bmw = _factory.BuildCar(_bmwCarBuilder);
            var porsche = _factory.BuildCar(_porscheCarBuilder);
            var toyota = _factory.BuildCar(_toyotaCarBuilder);

            cars = new[] {bmw, porsche, toyota};
        }
        
        private void Output()
        {
            foreach (var car in cars)
            {
                car.GetInfo();
            }
        }
    }
}