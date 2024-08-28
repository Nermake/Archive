using UnityEngine;

namespace Mori.Patterns.GeneratingPatterns.Builder.Example1
{
    public class Car
    {
        public string Name { get; set; }
        public Engine Engine { get; set; }
        public Transmission Transmission { get; set; }
        public Wheels Wheels { get; set; }
        
        public void GetInfo()
        {
            Debug.Log($"--- The brand of the car: {Name} --- \n" +
                      $"- Number of cylinders: {Engine.NumberOfCylinders} - \n" +
                      $"- Type of transmission: {Transmission.Type} - \n" +
                      $"- Type of Tire: {Wheels.TypeOfTire} - \n");
        }
    }
}