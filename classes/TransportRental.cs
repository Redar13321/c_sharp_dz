namespace ConsoleApp4.classes
{
    public class TransportRental<T> where T : ITransport
    {
        public string ClientName { get; }
        public T Transport { get; }
        public int RentalTimeMinutes { get; }

        public TransportRental(string clientName, T transport, int rentalTimeMinutes)
        {
            ClientName = clientName;
            Transport = transport;
            RentalTimeMinutes = rentalTimeMinutes;
        }

        public string GetRentalInfo()
        {
            string transportInfo = Transport switch
            {
                Scooter s => $"Scooter: {s.Model} ({s.Year})",
                Car c => $"Car: {c.Make} {c.Model} ({c.Color}, {c.LicensePlate})",
                _ => "Unknown transport"
            };

            return $"Client: {ClientName}\n" +
                   $"Transport: {typeof(T).GetProperty("TransportType").GetValue(null)}\n" +
                   $"{transportInfo}\n" +
                   $"Rental time: {RentalTimeMinutes} minutes\n" +
                   $"Cost per minute: {Transport.RentalCostPerMinute}";
        }

        public decimal CalculateTotalCost()
        {
            return Transport.RentalCostPerMinute * RentalTimeMinutes;
        }
    }
}
