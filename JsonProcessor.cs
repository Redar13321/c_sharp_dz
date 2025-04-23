using ConsoleApp5.artifact;
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

namespace ConsoleApp5
{
	public class JsonProcessor : IDataProcessor<ModernArtifact>
	{
		public List<ModernArtifact>? LoadData(string filePath)
		{
            JArray? jArray = null;
            try
            {
                using (StreamReader reader = new(filePath))
                {
                    jArray = JArray.Parse(reader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (jArray == null) return null;
            List<ModernArtifact> list = new();
            foreach (JToken item in jArray)
            {
                try
                {
                    ModernArtifact? artifact = item.ToObject<ModernArtifact>();
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

		public void SaveData(List<ModernArtifact> data, string filePath)
		{
            JArray jArray = new();
            foreach (ModernArtifact artifact in data)
            {
                try
                {
                    jArray.Add(JValue.Parse(artifact.Serialize()));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            using (StreamWriter writer = new(filePath))
            {
                writer.Write(jArray.ToString());
                writer.Flush();
            }

        }
	}
}
