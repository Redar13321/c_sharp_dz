using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.classes
{
    public class Triangle
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public double Perimeter()
        {
            return SideA + SideB + SideC;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Стороны: A = {SideA}, B = {SideB}, C = {SideC}");
            Console.WriteLine($"Периметр: {Perimeter()}");
        }
    }
}
