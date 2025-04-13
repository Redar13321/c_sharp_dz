namespace ConsoleApp3
{
    // 5. Attractions hierarchy
    public class Attraction
    {
        protected string Name { get; }
        protected int DurationMinutes { get; }
        protected int MaxCapacity { get; }

        public Attraction(string name, int durationMinutes, int maxCapacity)
        {
            Name = name;
            DurationMinutes = durationMinutes;
            MaxCapacity = maxCapacity;
        }

        public virtual string GetInfo() => $"Attraction: {Name}, Duration: {DurationMinutes} mins, Max capacity: {MaxCapacity}";
    }
}
