using Zenject;

namespace Mori.SDK.Zenject.Example.GameType
{
    public class Unit2
    {
        [Inject] private Unit1 _unit1;

        public void Log()
        {
            _unit1.Log();
        }
    }
}