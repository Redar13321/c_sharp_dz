using ConsoleApp5.artifact;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new ShopManager().Run();
            /*
            Console.WriteLine("Hello, World!");
            new LegendaryProcessor().SaveData([
                new(){
                    Name = "xcvxcvcvxcvxcv"
                },
                new()
            ], "xml.txt");

            List<LegendaryArtifact> list = new LegendaryProcessor().LoadData("xml.txt");

            if (list != null )
            foreach (LegendaryArtifact i in list)
            {
               Console.WriteLine(i.Name);
            }

            */
        }
    }
}
