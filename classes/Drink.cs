namespace ConsoleApp3
{
    public class Drink : MenuItem
    {
        private int VolumeMl { get; }

        public Drink(string name, decimal price, string category, int volumeMl)
            : base(name, price, category)
        {
            VolumeMl = volumeMl;
        }

        public decimal CalculateDiscountedPrice(int discountPercent)
        {
            return Price * (100 - discountPercent) / 100;
        }

        public override string GetInfo() => $"{base.GetInfo()}, Volume: {VolumeMl}ml";
    }
}
