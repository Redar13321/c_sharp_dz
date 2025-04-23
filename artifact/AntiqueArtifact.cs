using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConsoleApp5.artifact
{
    [Serializable]
    public class AntiqueArtifact : Artifact
    {
        public int Age { get; set; }
        public string OriginRealm { get; set; }
        public AntiqueArtifact()
        {
            Id = Guid.NewGuid();
            Name = "|NaN|";
            PowerLevel = 0;
            Rarity = 0;

            Age = 0;
            OriginRealm = "|NaN|";
        }
        public override XElement Serialize()
        {
            XElement xElement = new("AntiqueArtifact");
            xElement.Add(new XElement("Id", Id));
            xElement.Add(new XElement("Name", Name));
            xElement.Add(new XElement("PowerLevel", PowerLevel));
            xElement.Add(new XElement("Rarity", Rarity));
            xElement.Add(new XElement("Age", Age));
            xElement.Add(new XElement("OriginRealm", OriginRealm));
            return xElement;
        }
        public override string ToString()
        {
            return $"Name:{Name} PowerLevel:{PowerLevel} Rarity:{Rarity} Age:{Age} OriginRealm:{OriginRealm}";
        }
    }
}
