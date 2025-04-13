namespace ConsoleApp4.classes
{
    public class GameCharacter<T> where T : IWeapon
    {
        public string Name { get; }
        public string Race { get; }
        public T Weapon { get; }
        public int CharacterPower { get; }

        public GameCharacter(string name, string race, T weapon, int characterPower)
        {
            Name = name;
            Race = race;
            Weapon = weapon;
            CharacterPower = characterPower;
        }

        public string GetCharacterInfo()
        {
            string weaponInfo = Weapon switch
            {
                Sword s => $"Sword (Quality: {s.Quality})",
                Bow b => $"Bow (Range: {b.Range}, Accuracy: {b.Accuracy})",
                _ => "Unknown weapon"
            };

            return $"Character: {Name}\n" +
                   $"Race: {Race}\n" +
                   $"Weapon: {typeof(T).GetProperty("WeaponType").GetValue(null)}\n" +
                   $"{weaponInfo}\n" +
                   $"Weapon power: {Weapon.Power}\n" +
                   $"Special ability: {Weapon.SpecialAbility}\n" +
                   $"Character power: {CharacterPower}";
        }

        public int GetTotalPower()
        {
            return CharacterPower + Weapon.Power;
        }
    }
}
