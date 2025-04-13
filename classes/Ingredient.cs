namespace ConsoleApp5.classes
{
    public class Ingredient
    {
        public string Name { get; set; }
        public string Effect { get; set; }
        public double Price { get; set; }

        public static bool operator <(Ingredient a, Ingredient b) => a.Price < b.Price;
        public static bool operator >(Ingredient a, Ingredient b) => a.Price > b.Price;

        public static Ingredient operator +(Ingredient a, Ingredient b)
        {
            return new Ingredient
            {
                Name = "Potion",
                Effect = $"{a.Effect} + {b.Effect}",
                Price = (a.Price + b.Price) * 3
            };
        }
    }
}
