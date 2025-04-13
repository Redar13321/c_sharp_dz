namespace ConsoleApp5.classes
{
    public class Figure
    {
        public double CalculateVolume(double a) => Math.Pow(a, 3);
        public double CalculateVolume(double a, double b, double c) => a * b * c;

        public double CalculateVolume(double radius, double height) => Math.PI * Math.Pow(radius, 2) * height;
        public double CalculateVolumeCircl(double radius) => 4.0 / 3 * Math.PI * Math.Pow(radius, 3);

        public double CalculateSurfaceArea(double a) => 6 * Math.Pow(a, 2);
        public double CalculateSurfaceArea(double a, double b, double c) => 2 * (a * b + a * c + b * c);

        public double CalculateSurfaceArea(double radius, double height) => 2 * Math.PI * radius * (radius + height);
        public double CalculateSurfaceAreaCircl(double radius) => 4 * Math.PI * Math.Pow(radius, 2);

        public double CalculateArea(double a) => Math.Pow(a, 2);
        public double CalculateArea(double a, double b) => a * b;
        public double CalculateArea(double a, double b, bool isTriangle) => isTriangle ? a * b / 2 : 0;
        public double CalculateArea(double a, double b, double h) => (a + b) * h / 2;

        public double CalculatePerimeter(double a) => 4 * a;
        public double CalculatePerimeter(double a, double b) => 2 * (a + b);
        public double CalculatePerimeter(double a, double b, double c) => a + b + c;
        public double CalculatePerimeter(double a, double b, double c, double d) => a + b + 2 * c;
    }
}
