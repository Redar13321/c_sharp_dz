using ConsoleApp5.artifact;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class ShopManager
    {
        List<Artifact> Artifacts = new();
        XmlProcessor xmlProcessor = new();
        JsonProcessor jsonProcessor = new();
        LegendaryProcessor legendaryProcessor = new();
        public ShopManager() { }

        public void Run()
        {
            bool leave = false;
            while (!leave)
            {
                Console.WriteLine("0: выход");
                Console.WriteLine("1: загрузить магазин");
                Console.WriteLine("2: очистить магазин");
                Console.WriteLine("3: вывести список");
                Console.WriteLine("4: сохранить статистику артифактов");
                switch (Console.ReadLine())
                {
                    case "0":
                        leave = true;
                        break;
                    case "1":
                        LoadAllData();
                        break;
                    case "2":
                        Artifacts.Clear();
                        break;
                    case "3":
                        PrintList();
                        break;
                    case "4":
                        GenerateReport();
                        break;
                }
            }
        }

        public void LoadAllData()
        {
            Artifacts.Clear();
            string[] listFiles = Directory.GetFiles("./");
            foreach (string file in listFiles)
            {
                switch (Path.GetExtension(file))
                {
                    case ".xml":
                        var xdata = xmlProcessor.LoadData(file);
                        if (xdata != null)
                        {
                            foreach (var item in xdata)
                                Artifacts.Add(item);
                        }
                        break;
                    case ".json":
                        var jdata = jsonProcessor.LoadData(file);
                        if (jdata != null)
                        {
                            foreach (var item in jdata)
                                Artifacts.Add(item);
                        }
                        break;
                    case ".txt":
                        var ldata = legendaryProcessor.LoadData(file);
                        if (ldata != null)
                        {
                            foreach (var item in ldata)
                                Artifacts.Add(item);
                        }
                        break;

                }
            }
        }

        public void PrintList()
        {
            foreach (var item in Artifacts)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void GenerateReport()
        {
            StringBuilder sb = new StringBuilder();
            Rarity[] rarityes = {
                Rarity.Common,
                Rarity.Rare,
                Rarity.Epic,
                Rarity.Legendary
            };
            foreach (var rarity in rarityes)
            {
                string? e = GetReportByRarity(rarity);
                if (e != null && e.Length != 0)
                    sb.AppendLine(e);
            }
            sb.AppendLine("All:");
            sb.AppendLine($"\tCount: {Artifacts.Count}");
            sb.AppendLine($"\tMidPowerLevel: {Artifacts.Sum(i => i.PowerLevel) / Artifacts.Count}");
            using (StreamWriter writer = new("stats.txt"))
            {
                writer.Write(sb.ToString().TrimEnd());
                writer.Flush();
            }
        }
        string? GetReportByRarity(Rarity rarity)
        {
            List<Artifact> artifacts = Artifacts.Where(i => i.Rarity == rarity).ToList();
            if (artifacts.Count == 0) return null;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{rarity}:");
            sb.AppendLine($"\tCount: {artifacts.Count}");
            sb.AppendLine($"\tMidPowerLevel: {artifacts.Sum(i => i.PowerLevel) / artifacts.Count}");
            return sb.ToString().TrimEnd();
        }
    }
}
