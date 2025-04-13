namespace ConsoleApp5.classes
{
    public class Applicant
    {
        public string FullName { get; set; }
        public double AverageScore { get; set; }
        public double AchievementsScore { get; set; }
        public DateTime ApplicationDate { get; set; }

        public static bool operator <(Applicant a, Applicant b)
        {
            if (a.AverageScore == b.AverageScore)
                return a.AchievementsScore < b.AchievementsScore;
            return a.AverageScore < b.AverageScore;
        }

        public static bool operator >(Applicant a, Applicant b)
        {
            if (a.AverageScore == b.AverageScore)
                return a.AchievementsScore > b.AchievementsScore;
            return a.AverageScore > b.AverageScore;
        }
    }
}
