using ConsoleApp5.artifact;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp5
{
	public class LegendaryProcessor : IDataProcessor<LegendaryArtifact>
	{
		public List<LegendaryArtifact>? LoadData(string filePath)
		{
            string[]? strings = null;
            try
            {
                using (StreamReader reader = new(filePath))
                {
                    strings = reader.ReadToEnd().Replace("\r", "\n").Split("\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (strings == null) return null;
            List<LegendaryArtifact> list = new();
            foreach (string item in strings)
            {
                try
                {
                    LegendaryArtifact? artifact = LegendaryArtifact.Deserialize(item);
                    if (artifact != null)
                        list.Add(artifact);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
			return list;
        }

		public void SaveData(List<LegendaryArtifact> data, string filePath)
		{
            StringBuilder builder = new();
            foreach (LegendaryArtifact artifact in data)
            {
                builder.AppendLine(artifact.Serialize());
            }
            using (StreamWriter writer = new(filePath))
            {
                writer.Write(builder.ToString().TrimEnd());
                writer.Flush();
            }

        }
	}
}
