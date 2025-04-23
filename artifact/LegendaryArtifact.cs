using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.artifact
{
	public class LegendaryArtifact : Artifact
	{
		public bool IsCursed;
		public string CurseDescription;
		public LegendaryArtifact()
		{
			Id = Guid.NewGuid();
			Name = "|NaN|";
			PowerLevel = 0;
			Rarity = 0;

			IsCursed = true;
			CurseDescription = "|NaN|";
		}
        public static string SerializeString(string i) => i.Replace("|", "");
        public static LegendaryArtifact? Deserialize(string raw)
		{
            string[] strings = raw.Split("|");
            LegendaryArtifact artifact = new();
            if (strings.Length < 5) return null;
            artifact.Name = strings[0];
            artifact.PowerLevel = int.Parse(strings[1]);
            artifact.Rarity = (Rarity)Enum.Parse(typeof(Rarity), strings[2], true);
            artifact.CurseDescription = strings[3];
            artifact.IsCursed = Convert.ToBoolean(strings[4]);
            return artifact;
        }
        public override string Serialize()
        {
            StringBuilder list = new();
            list.AppendJoin("|", [
                    SerializeString(Name),
                    PowerLevel,
                    Rarity,
                    SerializeString(CurseDescription),
                    IsCursed
                ]);
            return list.ToString();
        }
        public override string ToString()
        {
            return $"Name:{Name} PowerLevel:{PowerLevel} Rarity:{Rarity} CurseDescription:{CurseDescription} IsCursed:{IsCursed}";
        }
    }
}
