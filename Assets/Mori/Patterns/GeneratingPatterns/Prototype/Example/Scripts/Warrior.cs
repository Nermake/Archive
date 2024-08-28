namespace Mori.Patterns.GeneratingPatterns.Prototype.Example
{
    public class Warrior : IPrototype<Warrior>
    {
        public string Name  {  get; set;  }
        public int Health {  get; set; }
        public int AttackPower {   get; set;  }

        public Warrior(string name, int health, int attackPower)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
        }

        public override string ToString()
        {
            var line = $"Name: {Name}, Health: {Health}, AttackPower: {AttackPower}";

            return line;
        } 

        public Warrior Clone() => (Warrior)MemberwiseClone();
    }
}