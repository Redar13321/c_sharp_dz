using System.Drawing;

namespace ConsoleApp3
{
    internal class Program
    {
        static int _jobCount = 0;
        static void printJob(Action job)
        {
            Console.WriteLine($"Задание {++_jobCount}");
            job();
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            printJob(() =>
            {
                FeaturesStudent student1 = new FeaturesStudent("John Doe", 101, "RB12345", "123-456-789 00");
                Console.WriteLine(student1.Information);
                student1.FullName = "John Smith";
                Console.WriteLine($"Updated name: {student1.FullName}");

                MethodStudent student2 = new MethodStudent("Alice Johnson", 102, "RB54321", "987-654-321 00");
                Console.WriteLine(student2.GetInformation());
                student2.SetFullName("Alice Brown");
                Console.WriteLine($"Updated name: {student2.GetFullName()}");
            });

            printJob(() =>
            {
                FeaturesCat cat1 = new FeaturesCat("Whiskers", "Siamese", 25.5, 4.2, "Mary");
                Console.WriteLine(cat1.Information);
                cat1.Weight = 4.5;
                Console.WriteLine($"Updated weight: {cat1.Weight} kg");

                MethodCat cat2 = new MethodCat("Fluffy", "Persian", 30.0, 5.1, "John");
                Console.WriteLine(cat2.GetInformation());
                cat2.SetHeight(31.0);
                Console.WriteLine($"Updated height: {cat2.GetHeight()} cm");
            });

            printJob(() =>
            {
                FeaturesCinema movie1 = new FeaturesCinema("Inception", 350.50m, 120, "Hall 5");
                Console.WriteLine(movie1.Information);
                movie1.MovieTitle = "Inception (Director's Cut)";
                Console.WriteLine($"Updated title: {movie1.MovieTitle}");

                MethodCinema movie2 = new MethodCinema("The Matrix", 300.00m, 150, "Hall 3");
                Console.WriteLine(movie2.GetInformation());
                movie2.SetViewersCount(160);
                Console.WriteLine($"Updated viewers count: {movie2.GetViewersCount()}");
            });

            printJob(() =>
            {
                Cat myCat = new Cat("Tom", 4.5, "Tabby", new DateTime(2018, 5, 12));
                Console.WriteLine(myCat.GetInfo());
                Console.WriteLine($"Did the cat catch a mouse? {myCat.CatchMouse()}");

                Parrot myParrot = new Parrot("Polly", 0.3, "African Grey", new DateTime(2020, 2, 20));
                Console.WriteLine(myParrot.GetInfo());
            });

            printJob(() =>
            {
                Tower tower = new Tower("Observation Tower", 10, 20, 150.50m);
                Console.WriteLine(tower.GetInfo());
                Console.WriteLine($"Revenue with 15 people: {tower.CalculateRevenue(15)}");
                Console.WriteLine($"Revenue at full capacity: {tower.CalculateRevenue()}");

                RollerCoaster coaster = new RollerCoaster("Thunder Bolt", 5, 30, 250.75m);
                Console.WriteLine(coaster.GetInfo());
                Console.WriteLine($"Revenue with 25 people: {coaster.CalculateRevenue(25)}");
            });

            printJob(() =>
            {
                Dish pasta = new Dish("Pasta Carbonara", 450.00m, "Italian", 650, 350);
                Console.WriteLine(pasta.GetInfo());
                Console.WriteLine($"Price per gram: {pasta.PricePerGram()}");

                Drink juice = new Drink("Orange Juice", 150.00m, "Beverages", 250);
                Console.WriteLine(juice.GetInfo());
                Console.WriteLine($"Price with 20% discount: {juice.CalculateDiscountedPrice(20)}");
            });
        }
    }
}
