namespace ConsoleApp5.classes
{
    public static class WorkAbility
    {
        public static int MinAge = 18;
        public static int MaxAge = 70;

        public static bool CheckPerson(Person person)
        {
            return person.Age >= MinAge && person.Age <= MaxAge;
        }
    }
}
