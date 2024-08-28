using UnityEngine;

namespace Mori.Patterns.StructuralPatterns.Bridge.Example
{
    public class CorporateProgrammer : Programmer
    {
        public CorporateProgrammer(ILanguage lang) : base(lang) { }
        public override void EarnMoney() => Debug.Log("Получаем в конце месяца зарплату");
    }
}