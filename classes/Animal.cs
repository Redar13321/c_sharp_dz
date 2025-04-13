namespace ConsoleApp3
{
    // 4. Animals hierarchy
    public class Animal
    {
        protected string Name { get; }
        protected double Weight { get; }
        protected string Breed { get; }
        protected DateTime BirthDate { get; }

        public Animal(string name, double weight, string breed, DateTime birthDate)
        {
            Name = name;
            Weight = weight;
            Breed = breed;
            BirthDate = birthDate;
        }

        public virtual string GetInfo() => $"Name: {Name}, Weight: {Weight} kg, Breed: {Breed}, Birth Date: {BirthDate:yyyy-MM-dd}";
    }
}
