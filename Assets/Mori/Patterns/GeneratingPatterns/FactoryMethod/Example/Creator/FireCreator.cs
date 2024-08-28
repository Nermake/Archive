using UnityEngine;

namespace Mori.Patterns.GeneratingPatterns.FactoryMethod.Example
{
    public class FireCreator : Creator
    {
        public override Mage FactoryMethod()
        {
            var mage = new Mage
            {
                Damage = 5,
                HP = 10,
                NameSpell = "Fire Ball"
            };
            
            Debug.Log("Create Fire Mage");

            return mage;
        }
    }
}