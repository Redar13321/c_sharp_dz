namespace ConsoleApp5.classes
{
    public static class Admission
    {
        public static double PassingScore = 4.5;

        public static bool CheckApplicant(Applicant applicant)
        {
            return applicant.AverageScore >= PassingScore;
        }
    }
}
