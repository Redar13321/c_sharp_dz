namespace ConsoleApp5.classes
{
    public class Game
    {
        public string Name { get; set; }
        public double AveragePlayers { get; set; }
        public double MaxPlayers { get; set; }
        public double Rating { get; set; }

        public static Game operator ++(Game game)
        {
            game.Rating = Math.Min(game.Rating + 0.1, 10);
            return game;
        }

        public static Game operator --(Game game)
        {
            game.Rating = Math.Max(game.Rating - 0.1, 0);
            return game;
        }
    }
}
