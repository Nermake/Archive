using UnityEngine;

namespace Mori.Patterns.AbstractFactory.Example
{
    public class RedMage : Mage
    {
        [SerializeField] private float _fireBallRadius;
        [SerializeField] private float _fireBallDamage;
        public void Init(float fireBallRadius, float fireBallDamage)
        {
            _fireBallRadius = fireBallRadius;
            _fireBallDamage = fireBallDamage;
        }
        public override void CastSpell()
        {
            Debug.Log("Кастую огренный шар!");
        }
    }
}