namespace ConsoleApp4.classes
{
    // Task 3
    public interface ITax
    {
        static string RussianName { get; }
        string ItemName { get; }
        decimal Price { get; }
        decimal AddTax();
    }
}
