using UnityEngine;

namespace Mori.Patterns.StructuralPatterns.Bridge.Example
{
    public class CSharpLanguage : ILanguage
    {
        public void Build() => Debug.Log("С помощью компилятора Roslyn компилируем исходный код в файл exe");
        public void Execute() => Debug.Log("JIT компилирует программу бинарный код \n CLR выполняет скомпилированный бинарный код");
    }
}