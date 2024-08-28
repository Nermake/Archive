using UnityEngine;

namespace Mori.Patterns.StructuralPatterns.FluentInterface.Example
{
    public class MainScript : MonoBehaviour
    {
        private void Start()
        {
            var config = new UnitsMainConfig(10);

            var unit1 = new Unit()
                .SetName("Unit_1")
                .SetDescription("hahaha")
                .SetBaseDamage(7, config)
                .WithWeapon(new Weapon("1"));
            
            Debug.Log(unit1);
            
            var unit2 = new Unit()
                .SetName("Unit_2")
                .SetDescription("hihihi")
                .SetBaseDamage(-8, config)
                .WithWeapon(new Weapon("2"));
            
            Debug.Log(unit2);
        }
    }
}