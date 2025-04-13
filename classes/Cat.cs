namespace ConsoleApp3
{
    public class Cat : Animal
    {
        public Cat(string name, double weight, string breed, DateTime birthDate)
            : base(name, weight, breed, birthDate) { }

        public bool CatchMouse()
        {
            Random rnd = new Random();
            return rnd.Next(0, 100) > 50;
        }

        public override string GetInfo() => $"Cat - {base.GetInfo()}";
    }
}
