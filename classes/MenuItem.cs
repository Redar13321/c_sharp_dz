namespace ConsoleApp3
{
    // 6. Cafe menu hierarchy
    public class MenuItem
    {
        protected string Name { get; }
        protected decimal Price { get; }
        protected string Category { get; }

        public MenuItem(string name, decimal price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }

        public virtual string GetInfo() => $"{Name} ({Category}), Price: {Price}";
    }
}
