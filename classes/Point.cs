using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.classes
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public void MoveBy(double dx, double dy, double dz)
        {
            X += dx;
            Y += dy;
            Z += dz;
        }
    }

}
