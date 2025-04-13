namespace ConsoleApp5.classes
{
    public class Credit
    {
        public string BorrowerName { get; set; }
        public double PaymentAmount { get; set; }
        public static double InterestRate = 10.0;

        public static Credit operator -(Credit credit, double payment)
        {
            credit.PaymentAmount -= payment;
            return credit;
        }

        public static double GetInterestRate() => InterestRate;
    }
}
