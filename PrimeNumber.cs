using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class PrimeNumber
    {
        public int MaxIterrations = 10000; // int.MaxValue
        public PrimeNumber() { }
        public IEnumerable<int> GetPrimes(int limit)
        {
            int n = 2;

            while (n < limit)
            {
                if (IsPrime(n))
                {
                    yield return n;
                }
                n++;
            }
        }
        public bool IsPrime(int n)
        {
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
        public IEnumerable<int> GetAllPrimes()
        {
            return GetPrimes(MaxIterrations);
        }

        public IEnumerable<int> SkipPrimes(int count)
        {
            int n = count;
            int MaxIterrations = this.MaxIterrations;
            while (n < MaxIterrations)
            {
                if (IsPrime(n))
                {
                    yield return n;
                }
                n++;
            }
        }
    }
}
