namespace ConsoleApp3
{
    public class Parrot : Animal
    {
        public Parrot(string name, double weight, string breed, DateTime birthDate)
            : base(name, weight, breed, birthDate) { }

        public override string GetInfo() => $"Parrot - {base.GetInfo()}";
    }
}
