namespace ConsoleApp4.classes
{
    public struct Sword : IWeapon
    {
        public static string WeaponType => "Sword";
        public int Power { get; }
        public string SpecialAbility { get; }
        public string Quality { get; } // Normal, Good, Unique

        public Sword(int power, string specialAbility, string quality)
        {
            Power = power;
            SpecialAbility = specialAbility;
            Quality = quality;
        }
    }
}
