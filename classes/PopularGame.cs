namespace ConsoleApp5.classes
{
    public static class PopularGame
    {
        public static double Rating = 8.5;
        public static double AveragePlayers = 1000;
        public static double MaxPlayers = 10000;

        public static bool CheckGame(Game game)
        {
            return game.Rating >= Rating &&
                   game.AveragePlayers >= AveragePlayers &&
                   game.MaxPlayers >= MaxPlayers;
        }
    }
}
