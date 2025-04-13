namespace ConsoleApp4.classes
{
    public class NecessityItem : ITax, IConsoleOutput
    {
        public static string RussianName => "Предметы первой необходимости";
        public string ItemName { get; }
        public decimal Price { get; }

        public NecessityItem(string itemName, decimal price)
        {
            ItemName = itemName;
            Price = price;
        }

        public decimal AddTax()
        {
            return Price * 1.005m; // 0.5% tax
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
