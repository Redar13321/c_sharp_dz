namespace ConsoleApp4.classes
{
    // Task 5
    public struct CarStruct
    {
        public string EngineVIN { get; }
        public string Make { get; }
        public string Model { get; }
        public int Year { get; }
        public string Color { get; }

        public string Info => $"Car: {Make} {Model} ({Year}, {Color}), VIN: {EngineVIN}";

        public CarStruct(string vin, string make, string model, int year, string color)
        {
            EngineVIN = vin;
            Make = make;
            Model = model;
            Year = year;
            Color = color;
        }

        public string CheckVIN(string actualVIN)
        {
            return actualVIN == EngineVIN ? "VIN matches!" : "VIN doesn't match!";
        }
    }
}
