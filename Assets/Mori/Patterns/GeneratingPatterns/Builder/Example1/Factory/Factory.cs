namespace Mori.Patterns.GeneratingPatterns.Builder.Example1
{
    public class Factory
    {
        public Car BuildCar(CarBuilder carBuilder)
        {
            carBuilder.CreateCar();
            carBuilder.SetBrand();
            carBuilder.SetEngine();
            carBuilder.SetTransmission();
            carBuilder.SetWheels();
            
            return carBuilder.Car;
        }
    }
}