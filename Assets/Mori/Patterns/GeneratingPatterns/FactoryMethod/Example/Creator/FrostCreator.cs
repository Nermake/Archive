using UnityEngine;

namespace Mori.Patterns.GeneratingPatterns.FactoryMethod.Example
{
    public class FrostCreator : Creator
    {
        public override Mage FactoryMethod()
        {
            var mage = new Mage
            {
                Damage = 4,
                HP = 11,
                NameSpell = "Frost Bolt" 
            };
            Debug.Log("Create Frost Mage");

            return mage;
        }
    }
}