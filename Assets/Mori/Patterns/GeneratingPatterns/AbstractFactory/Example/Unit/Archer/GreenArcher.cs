using UnityEngine;

namespace Mori.Patterns.AbstractFactory.Example
{
    public class GreenArcher : Archer
    {
        public override void Shoot()
        {
            Debug.Log("Стреляю как Робин Гуд!");
        }
    }
}