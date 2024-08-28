using UnityEngine;

namespace Mori.Patterns.AbstractFactory.Example
{
    public class BlueArcher : Archer
    {
        public override void Shoot()
        {
            Debug.Log("Стреляю ледяной стрелой!");
        }
    }
}