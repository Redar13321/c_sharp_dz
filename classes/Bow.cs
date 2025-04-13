namespace ConsoleApp4.classes
{
    public struct Bow : IWeapon
    {
        public static string WeaponType => "Bow";
        public int Power { get; }
        public string SpecialAbility { get; }
        public int Range { get; } // 1-100
        public int Accuracy { get; } // 1-100

        public Bow(int power, string specialAbility, int range, int accuracy)
        {
            Power = power;
            SpecialAbility = specialAbility;
            Range = range;
            Accuracy = accuracy;
        }
    }
}
