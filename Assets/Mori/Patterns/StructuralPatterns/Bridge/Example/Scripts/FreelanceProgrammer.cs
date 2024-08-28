using UnityEngine;

namespace Mori.Patterns.StructuralPatterns.Bridge.Example
{
    public class FreelanceProgrammer : Programmer
    {
        public FreelanceProgrammer(ILanguage lang) : base(lang) { }
        public override void EarnMoney() => Debug.Log("Получаем оплату за выполненный заказ");
    }
}