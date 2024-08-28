namespace Mori.Patterns.GeneratingPatterns.Builder.Example1
{
    public class BmwCarBuilder : CarBuilder
    {
        public override void SetBrand()
        {
            Car.Name = "Bmw";
        }
        
        public override void SetEngine()
        {
            Car.Engine = new Engine { NumberOfCylinders = 6 };
        }

        public override void SetTransmission()
        {
            Car.Transmission = new Transmission { Type = "Type_1"};
        }

        public override void SetWheels()
        {
            Car.Wheels = new Wheels { TypeOfTire = "TypeOfTire_1"};
        }
    }
}