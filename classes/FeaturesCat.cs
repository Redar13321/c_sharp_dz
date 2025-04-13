namespace ConsoleApp3
{
    // 2. Cat classes
    public class FeaturesCat
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Breed { get; }

        private double _height;
        public double Height
        {
            get => _height;
            set => _height = value;
        }

        private double _weight;
        public double Weight
        {
            get => _weight;
            set => _weight = value;
        }

        public string Owner { get; }

        public FeaturesCat(string name, string breed, double height, double weight, string owner)
        {
            _name = name;
            Breed = breed;
            _height = height;
            _weight = weight;
            Owner = owner;
        }

        public string Information => $"Cat: {Name}, Breed: {Breed}, Height: {Height} cm, Weight: {Weight} kg, Owner: {Owner}";
    }
}
