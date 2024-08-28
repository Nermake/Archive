using UnityEngine;

namespace Mori.Patterns.AbstractFactory.Example
{
    public class BlueMage : Mage
    {
        [SerializeField] private float _slowKoef;

        public void Init(float slowKoef)
        {
            _slowKoef = slowKoef;
        }

        public override void CastSpell()
        {
            Debug.Log("Кастую ледяную стрелу!");
        }
    }
}