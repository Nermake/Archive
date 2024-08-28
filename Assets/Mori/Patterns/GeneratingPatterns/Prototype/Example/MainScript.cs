using UnityEngine;

namespace Mori.Patterns.GeneratingPatterns.Prototype.Example
{
    public class MainScript : MonoBehaviour
    {
        private void Start()
        {
            var arms = new Warrior("Arms", 100, 20);

            var prot = arms.Clone();
            prot.Name = "Prot";
            prot.Health = 150;
            prot.AttackPower = 15;

            Debug.Log(arms);
            Debug.Log(prot);
        }
    }
}