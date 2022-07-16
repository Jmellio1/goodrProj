namespace DataAccessLibrary.Model
{
    public class GameInfo
    {
        public int Game { get; set; }
        public DateTime time { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }
        public string Logo1 { get; set; }
        public string Logo2 { get; set; }
    }
}
