using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp5
{
	public abstract class Artifact
    {
        [JsonIgnore]
        public Guid Id { get; set; }
		public string Name { get; set; }
		public int PowerLevel { get; set; }
		public Rarity Rarity { get; set; }

        public abstract dynamic? Serialize();
	}
}
