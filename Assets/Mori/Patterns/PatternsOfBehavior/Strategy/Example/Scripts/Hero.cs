using JetBrains.Annotations;
using UnityEngine;

namespace Mori.Patterns.PatternsOfBehavior.Strategy.Example
{
    public class Hero
    {
        private readonly string _name;
        private string _message;
        [CanBeNull] private IWeapon _weapon; // <=> private IWeapon? _weapon;

        public Hero(string name) => _name = name;
        
        public void SetWeapon(IWeapon weapon) => _weapon = weapon;

        public void Attack()
        {
            if (_weapon is null)
            {
                _message += $"{_name}, can't attack. Set a weapon. \n";
                
                Debug.Log(_message);
                
                _message = null;
                
                return;
            }

            _message += $"{_name}, stands menacingly. \n" +
                        $"{_name}, {_weapon.Shoot()}" +
                        $"{_name}, ceases to stand menacingly. \n \n";
            
            Debug.Log(_message);

            _message = null;
        }
    }
}