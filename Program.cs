namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrimeNumber primNum = new();

            foreach (var arg in primNum.GetPrimes(50))
            {
                Console.Write($"{arg}, ");
            }
            Console.WriteLine();
            Console.WriteLine();

            foreach (var arg in primNum.SkipPrimes(400))
            {
                Console.Write($"{arg}, ");
            }
            Console.WriteLine();
            Console.WriteLine();

            foreach (var arg in primNum.GetAllPrimes())
            {
                Console.Write($"{arg}, ");
            }
            Console.WriteLine();
            Console.WriteLine();

        }
    }
}
