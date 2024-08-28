namespace Mori.Patterns.StructuralPatterns.Services.Locator.Example
{
    public class ServiceTwo : IService
    {
        private int _speed;
        private ServiceTwo _serviceTwo;

        public void Init()
        {
            _speed = 10;
        }

        public int GetSpeed() => _speed;
    }
}