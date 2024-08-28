using UnityEngine;

namespace Mori.Patterns.AbstractFactory.Example
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] protected int _health;
        [SerializeField] protected float _attackValue;
    }
}