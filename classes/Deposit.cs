namespace ConsoleApp5.classes
{
    public class Deposit
    {
        public string DepositorName { get; set; }
        public double Amount { get; set; }
        public static double InterestRate = 5.0;

        public static Deposit operator ++(Deposit deposit)
        {
            deposit.Amount *= 1 + InterestRate / 100;
            return deposit;
        }

        public static double GetInterestRate() => InterestRate;
    }
}
