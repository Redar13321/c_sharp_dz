namespace ConsoleApp5
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Figure figure = new Figure();
            Console.WriteLine($"Cube volume: {figure.CalculateVolume(3)}");
            Console.WriteLine($"Parallelepiped volume: {figure.CalculateVolume(2, 3, 4)}");

            Console.WriteLine($"Cylinder volume: {figure.CalculateVolume(2, 5)}");
            Console.WriteLine($"Sphere volume: {figure.CalculateVolumeCircl(3)}");

            Console.WriteLine($"Cube surface area: {figure.CalculateSurfaceArea(3)}");
            Console.WriteLine($"Parallelepiped surface area: {figure.CalculateSurfaceArea(2, 3, 4)}");

            Console.WriteLine($"Cylinder surface area: {figure.CalculateSurfaceArea(2, 5)}");
            Console.WriteLine($"Sphere surface area: {figure.CalculateSurfaceAreaCircl(3)}");

            Console.WriteLine($"Square area: {figure.CalculateArea(5)}");
            Console.WriteLine($"Rectangle area: {figure.CalculateArea(4, 6)}");
            Console.WriteLine($"Triangle area: {figure.CalculateArea(3, 4, true)}");
            Console.WriteLine($"Trapezoid area: {figure.CalculateArea(5, 7, 4)}");

            Console.WriteLine($"Square perimeter: {figure.CalculatePerimeter(5)}");
            Console.WriteLine($"Rectangle perimeter: {figure.CalculatePerimeter(4, 6)}");
            Console.WriteLine($"Triangle perimeter: {figure.CalculatePerimeter(3, 4, 5)}");
            Console.WriteLine($"Trapezoid perimeter: {figure.CalculatePerimeter(5, 7, 4, 4)}");

            Numbers numbers = new Numbers();
            Console.WriteLine($"Max of 2 numbers: {numbers.GetMax(5, 9)}");
            Console.WriteLine($"Max of 3 numbers: {numbers.GetMax(5, 9, 3)}");
            Console.WriteLine($"Max of 4 numbers: {numbers.GetMax(5, 9, 3, 7)}");
            Console.WriteLine($"Max of 5 numbers: {numbers.GetMax(5, 9, 3, 7, 2)}");

            Arrays arrays = new Arrays();
            int[] intArray = { 1, 2, 3, 4, 5 };
            double[] doubleArray = { 1.1, 2.2, 3.3, 4.4, 5.5 };
            Console.WriteLine($"Int array average: {arrays.CalculateAverage(intArray)}");
            Console.WriteLine($"Double array average: {arrays.CalculateAverage(doubleArray)}");

            Console.WriteLine($"Int array max: {arrays.FindMax(intArray)}");
            Console.WriteLine($"Double array max: {arrays.FindMax(doubleArray)}");

            Console.WriteLine($"uint multiply: {numbers.Multiply(5u, 3u)}");
            Console.WriteLine($"int multiply: {numbers.Multiply(5, 3)}");
            Console.WriteLine($"long multiply: {numbers.Multiply(5L, 3L)}");
            Console.WriteLine($"double multiply: {numbers.Multiply(5.0, 3.0)}");
        }
    }}
