using UnityEngine;

namespace Mori.Patterns.AbstractFactory.Example
{
    public class GreenMage : Mage
    {
        public override void CastSpell()
        {
            Debug.Log("Кастую хилл!");
        }
    }
}