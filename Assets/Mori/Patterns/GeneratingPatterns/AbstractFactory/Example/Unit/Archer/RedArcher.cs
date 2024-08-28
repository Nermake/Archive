using UnityEngine;

namespace Mori.Patterns.AbstractFactory.Example
{
    public class RedArcher : Archer
    {
        [SerializeField] private float _fireArrowDamage;
        public void Init(float fireArrowDamage, float rangeDistance)
        {
            _fireArrowDamage = fireArrowDamage;
            base.Init(rangeDistance);
        }
        public override void Shoot()
        {
            Debug.Log("Стреляю огненной стрелой!");
        }
    }
}