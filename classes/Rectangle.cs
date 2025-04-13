using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.classes
{
    public class Rectangle
    {
        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public double Perimeter()
        {
            double width = Math.Abs(BottomRight.X - TopLeft.X);
            double height = Math.Abs(TopLeft.Y - BottomRight.Y);
            return 2 * (width + height);
        }

        public double Area()
        {
            double width = Math.Abs(BottomRight.X - TopLeft.X);
            double height = Math.Abs(TopLeft.Y - BottomRight.Y);
            return width * height;
        }
    }
}
