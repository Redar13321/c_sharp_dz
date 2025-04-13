using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.classes
{
    public class Smartphone
    {
        public string Model { get; set; }
        public double CpuFrequency { get; set; }
        public int RamSize { get; set; }
        public int StorageSize { get; set; }
        public string OsType { get; set; }
        public double Weight { get; set; }

        public string Info
        {
            get
            {
                return $"Модель: {Model}, Частота CPU: {CpuFrequency} GHz, RAM: {RamSize} GB, Память: {StorageSize} GB, ОС: {OsType}, Вес: {Weight} g";
            }
        }
    }
}
