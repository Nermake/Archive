namespace Mori.Patterns.GeneratingPatterns.Builder.Example1
{
    public class ToyotaCarBuilder : CarBuilder
    {
        public override void SetBrand()
        {
            Car.Name = "Toyota";
        }
        
        public override void SetEngine()
        {
            Car.Engine = new Engine { NumberOfCylinders = 4 };
        }

        public override void SetTransmission()
        {
            Car.Transmission = new Transmission { Type = "Type_3"};
        }

        public override void SetWheels()
        {
            Car.Wheels = new Wheels { TypeOfTire = "TypeOfTire_3"};
        }
    }
}