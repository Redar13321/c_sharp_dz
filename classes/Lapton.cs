using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.classes
{
    public class Laptop
    {
        public string Model { get; set; }
        public double CpuFrequency { get; set; }
        public int RamSize { get; set; }
        public int HddSize { get; set; }
        public double Weight { get; set; }

        public string Info()
        {
            return $"Модель: {Model}, Частота CPU: {CpuFrequency} GHz, RAM: {RamSize} GB, HDD: {HddSize} GB, Вес: {Weight} kg";
        }
    }
}
