namespace ConsoleApp3
{
    public class MethodCinema
    {
        private string _movieTitle;
        private readonly decimal _ticketPrice;
        private int _viewersCount;
        private readonly string _screeningHall;

        public string GetMovieTitle() => _movieTitle;
        public void SetMovieTitle(string value) => _movieTitle = value;
        public decimal GetTicketPrice() => _ticketPrice;
        public int GetViewersCount() => _viewersCount;
        public void SetViewersCount(int value) => _viewersCount = value;
        public string GetScreeningHall() => _screeningHall;

        public MethodCinema(string movieTitle, decimal ticketPrice, int viewersCount, string screeningHall)
        {
            _movieTitle = movieTitle;
            _ticketPrice = ticketPrice;
            _viewersCount = viewersCount;
            _screeningHall = screeningHall;
        }

        public string GetInformation() => $"Movie: {GetMovieTitle()}, Ticket price: {GetTicketPrice()}, Viewers: {GetViewersCount()}, Hall: {GetScreeningHall()}";
    }
}
