namespace Mori.Patterns.GeneratingPatterns.Builder.Example1
{
    public class PorscheCarBuilder : CarBuilder
    {
        public override void SetBrand()
        {
            Car.Name = "Porsche";
        }
        
        public override void SetEngine()
        {
            Car.Engine = new Engine { NumberOfCylinders = 8 };
        }

        public override void SetTransmission()
        {
            Car.Transmission = new Transmission { Type = "Type_2"};
        }

        public override void SetWheels()
        {
            Car.Wheels = new Wheels { TypeOfTire = "TypeOfTire_2"};
        }
    }
}