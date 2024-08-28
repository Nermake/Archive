using UnityEngine;

namespace Mori.Patterns.GeneratingPatterns.FactoryMethod.Example
{
    public class Mage
    {
        public int Damage { get; set; }
        public int HP { get; set; }
        
        public string NameSpell { get; set; }

        public void CastSpell()
        {
            Debug.Log($"I'm casting - {NameSpell}");
        }
        
        public override string ToString()
        {
            var line = $"Damage: {Damage} \n" +
                       $"HP: {HP} \n";

            return line;
        }
    }
}