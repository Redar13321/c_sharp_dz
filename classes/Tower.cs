namespace ConsoleApp3
{
    public class Tower : Attraction
    {
        private decimal RidePrice { get; }

        public Tower(string name, int durationMinutes, int maxCapacity, decimal ridePrice)
            : base(name, durationMinutes, maxCapacity)
        {
            RidePrice = ridePrice;
        }

        public decimal CalculateRevenue(int peopleCount = -1)
        {
            int count = peopleCount == -1 ? MaxCapacity : peopleCount;
            return count * RidePrice;
        }

        public override string GetInfo() => $"Tower - {base.GetInfo()}, Price per ride: {RidePrice}";
    }
}
