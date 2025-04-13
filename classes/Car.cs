namespace ConsoleApp4.classes
{
    public struct Car : ITransport
    {
        public static string TransportType => "Car";
        public decimal RentalCostPerMinute { get; }
        public string LicensePlate { get; }
        public string Make { get; }
        public string Model { get; }
        public string Color { get; }

        public Car(decimal cost, string licensePlate, string make, string model, string color)
        {
            RentalCostPerMinute = cost;
            LicensePlate = licensePlate;
            Make = make;
            Model = model;
            Color = color;
        }
    }
}
