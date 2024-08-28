using UnityEngine;

namespace Mori.Patterns.AbstractFactory.Example
{
    public class RedKnight : Knight
    {
        [SerializeField] private float _redKnightKoef;
        public void Init(float redKnightKoef)
        {
            _redKnightKoef = redKnightKoef;
        }
        public override void Parry()
        {
            Debug.Log("Наношу огненный удар!");
        }
    }
}