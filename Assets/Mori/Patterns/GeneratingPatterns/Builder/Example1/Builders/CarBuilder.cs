namespace Mori.Patterns.GeneratingPatterns.Builder.Example1
{
    public abstract class CarBuilder
    {
        public Car Car { get; private set; }
        public void CreateCar()
        {
            Car = new Car();
        }

        public abstract void SetBrand();
        public abstract void SetEngine();
        public abstract void SetTransmission();
        public abstract void SetWheels();
    }
}