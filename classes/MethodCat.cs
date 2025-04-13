namespace ConsoleApp3
{
    public class MethodCat
    {
        private string _name;
        private readonly string _breed;
        private double _height;
        private double _weight;
        private readonly string _owner;

        public string GetName() => _name;
        public void SetName(string value) => _name = value;
        public string GetBreed() => _breed;
        public double GetHeight() => _height;
        public void SetHeight(double value) => _height = value;
        public double GetWeight() => _weight;
        public void SetWeight(double value) => _weight = value;
        public string GetOwner() => _owner;

        public MethodCat(string name, string breed, double height, double weight, string owner)
        {
            _name = name;
            _breed = breed;
            _height = height;
            _weight = weight;
            _owner = owner;
        }

        public string GetInformation() => $"Cat: {GetName()}, Breed: {GetBreed()}, Height: {GetHeight()} cm, Weight: {GetWeight()} kg, Owner: {GetOwner()}";
    }
}
