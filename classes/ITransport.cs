namespace ConsoleApp4.classes
{
    // Task 1
    public interface ITransport
    {
        static string TransportType { get; }
        decimal RentalCostPerMinute { get; }
    }
}
