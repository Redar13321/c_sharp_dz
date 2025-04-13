namespace ConsoleApp3
{
    public class RollerCoaster : Attraction
    {
        private decimal RidePrice { get; }

        public RollerCoaster(string name, int durationMinutes, int maxCapacity, decimal ridePrice)
            : base(name, durationMinutes, maxCapacity)
        {
            RidePrice = ridePrice;
        }

        public decimal CalculateRevenue(int peopleCount = -1)
        {
            int count = peopleCount == -1 ? MaxCapacity : peopleCount;
            return count * RidePrice;
        }

        public override string GetInfo() => $"Roller Coaster - {base.GetInfo()}, Price per ride: {RidePrice}";
    }
}
