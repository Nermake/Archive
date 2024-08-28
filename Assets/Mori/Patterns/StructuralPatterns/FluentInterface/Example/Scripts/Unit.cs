namespace Mori.Patterns.StructuralPatterns.FluentInterface.Example
{
    public class Unit
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Weapon Weapon { get; set; }
        public int BaseDamage { get; set; }

        public override string ToString()
        {
            var line = $"Unit: {Name} \n" +
                       $"Description: {Description} \n" +
                       $"Weapon: {Weapon.ID} \n" +
                       $"BaseDamage: {BaseDamage} \n";

            return line;
        }
    }
}