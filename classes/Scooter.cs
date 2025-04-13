namespace ConsoleApp4.classes
{
    public struct Scooter : ITransport
    {
        public static string TransportType => "Scooter";
        public decimal RentalCostPerMinute { get; }
        public string Model { get; }
        public int Year { get; }

        public Scooter(decimal cost, string model, int year)
        {
            RentalCostPerMinute = cost;
            Model = model;
            Year = year;
        }
    }
}
