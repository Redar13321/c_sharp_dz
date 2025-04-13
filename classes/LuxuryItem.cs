namespace ConsoleApp4.classes
{
    public class LuxuryItem : ITax, IConsoleOutput
    {
        public static string RussianName => "Предметы роскоши";
        public string ItemName { get; }
        public decimal Price { get; }

        public LuxuryItem(string itemName, decimal price)
        {
            ItemName = itemName;
            Price = price;
        }

        public decimal AddTax()
        {
            return Price * 1.20m; // 20% tax
        }

        public void Print()
        {
            Console.WriteLine($"Категория: {RussianName}");
            Console.WriteLine($"Товар: {ItemName}");
            Console.WriteLine($"Цена без налога: {Price}");
            Console.WriteLine($"Цена с налогом: {AddTax()}");
        }
    }
}
