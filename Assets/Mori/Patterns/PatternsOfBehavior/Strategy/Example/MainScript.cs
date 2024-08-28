using UnityEngine;

namespace Mori.Patterns.PatternsOfBehavior.Strategy.Example
{
    public class MainScript : MonoBehaviour
    {
        private void Start()
        {
            var hero_Tom = new Hero("Tom");
            var hero_Den = new Hero("Den");
            
            hero_Tom.Attack();
            
            hero_Den.SetWeapon(new Plunger());
            hero_Den.Attack();
            
            hero_Tom.SetWeapon(new Broom());
            hero_Tom.Attack();
            
            hero_Den.SetWeapon(new WaterGun());
            hero_Den.Attack();
        }
    }
}