using DataAccessLibrary.Model;
namespace DataAccessLibrary
{
    public interface IAPIcall
    {
        Task<List<GameInfo>> Call(int team1, int team2, int season);
    }
}