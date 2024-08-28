using UnityEngine;

namespace Mori.Patterns.AbstractFactory.Example
{
    public class GreenKnight : Knight
    {
        public override void Parry()
        {
            Debug.Log("Наношу стремительный удар!");
        }
    }
}