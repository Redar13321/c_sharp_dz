namespace ConsoleApp5.classes
{
    public class Numbers
    {
        public int GetMax(int a, int b) => Math.Max(a, b);
        public int GetMax(int a, int b, int c) => GetMax(GetMax(a, b), c);
        public int GetMax(int a, int b, int c, int d) => GetMax(GetMax(a, b, c), d);
        public int GetMax(int a, int b, int c, int d, int e) => GetMax(GetMax(a, b, c, d), e);

        public uint Multiply(uint a, uint b) => a * b + 1;
        public int Multiply(int a, int b) => a * b + 2;
        public long Multiply(long a, long b) => a * b + 3;
        public double Multiply(double a, double b) => a * b + 0.1;
    }
}
