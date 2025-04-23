using ConsoleApp5.artifact;
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
	public class XmlProcessor : IDataProcessor<AntiqueArtifact>
	{
		public List<AntiqueArtifact>? LoadData(string filePath)
		{
			XDocument? doc = null;
			XmlSerializer serializer = new(typeof(AntiqueArtifact));
			try
			{
				using (StreamReader reader = new(filePath))
				{
					doc = XDocument.Load(reader);
				}
			}
			catch (Exception ex) {
				Console.WriteLine(ex);
			}
			if (doc == null) 
				return null;
			List<AntiqueArtifact> list = new();
			foreach (XElement element in doc.Descendants("AntiqueArtifact"))
            {
                try
                {
                    AntiqueArtifact? artifact = (AntiqueArtifact?)serializer.Deserialize(element.CreateReader());
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

		public void SaveData(List<AntiqueArtifact> data, string filePath)
		{
			XDocument doc = new();
			XElement list = new("ArrayOfAntiqueArtifact");
			doc.Add(list);
			foreach (AntiqueArtifact artifact in data)
			{
				list.Add((XElement) artifact.Serialize());
			}
			doc.Save(filePath);
		}
	}
}
