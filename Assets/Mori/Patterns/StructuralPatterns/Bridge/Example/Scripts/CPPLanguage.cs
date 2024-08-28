using UnityEngine;

namespace Mori.Patterns.StructuralPatterns.Bridge.Example
{
    public class CPPLanguage : ILanguage
    {
        public void Build() => Debug.Log("С помощью компилятора C++ компилируем программу в бинарный код");
        public void Execute() => Debug.Log("Запускаем исполняемый файл программы");
    }
}