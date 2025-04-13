namespace ConsoleApp5.classes
{
    public class Arrays
    {
        public double CalculateAverage(int[] array)
        {
            double sum = 0;
            foreach (var num in array) sum += num;
            return sum / array.Length;
        }

        public double CalculateAverage(double[] array)
        {
            double sum = 0;
            foreach (var num in array) sum += num;
            return sum / array.Length;
        }

        public int FindMax(int[] array)
        {
            int max = array[0];
            foreach (var num in array) if (num > max) max = num;
            return max;
        }

        public double FindMax(double[] array)
        {
            double max = array[0];
            foreach (var num in array) if (num > max) max = num;
            return max;
        }
    }
}
