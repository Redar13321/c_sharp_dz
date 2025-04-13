namespace ConsoleApp3
{
    // 3. Cinema classes
    public class FeaturesCinema
    {
        private string _movieTitle;
        public string MovieTitle
        {
            get => _movieTitle;
            set => _movieTitle = value;
        }

        public decimal TicketPrice { get; }
        private int _viewersCount;
        public int ViewersCount
        {
            get => _viewersCount;
            set => _viewersCount = value;
        }

        public string ScreeningHall { get; }

        public FeaturesCinema(string movieTitle, decimal ticketPrice, int viewersCount, string screeningHall)
        {
            _movieTitle = movieTitle;
            TicketPrice = ticketPrice;
            _viewersCount = viewersCount;
            ScreeningHall = screeningHall;
        }

        public string Information => $"Movie: {MovieTitle}, Ticket price: {TicketPrice}, Viewers: {ViewersCount}, Hall: {ScreeningHall}";
    }
}
