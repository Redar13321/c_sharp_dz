using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp5.artifact
{
    public class ModernArtifact : Artifact
    {
        public double TechLevel { get; set; }
        public string Manufacturer { get; set; }
        public ModernArtifact()
        {
            Id = Guid.NewGuid();
            Name = "|NaN|";
            PowerLevel = 0;
            Rarity = 0;

            TechLevel = 0;
            Manufacturer = "|NaN|";
        }
        public override string Serialize()
        {
            return JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }
        public override string ToString()
        {
            return $"Name:{Name} PowerLevel:{PowerLevel} Rarity:{Rarity} TechLevel:{TechLevel} Manufacturer:{Manufacturer}";
        }
    }
}
