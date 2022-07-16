using Newtonsoft.Json.Linq;
using System.Net.Http;
using DataAccessLibrary.Model;

namespace DataAccessLibrary
{
    public class APIcall : IAPIcall
    {
        private static  HttpClient client = new HttpClient();
        public async Task<List<GameInfo>> Call(int team1,int team2,int season)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "0bc50516e8msh6a510fc2b729d03p194455jsn5ebebdca214a");
            var response = await client.GetAsync("https://api-nba-v1.p.rapidapi.com/games?season="+season+"&h2h="+team1+"-"+team2);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var results = JObject.Parse(responseString).DescendantsAndSelf()
                  .OfType<JProperty>()
                  .Single(x => x.Name.Equals("response"))
                  .Value;
                List<GameInfo> games = new List<GameInfo>();
                int count = 1;
                foreach(JObject obj in results.Children<JObject>())
                {

                    
                    GameInfo gameInfo = new GameInfo
                    {
                        Team1 = obj["teams"]["home"]["name"].ToString(),
                        Team2 = obj["teams"]["visitors"]["name"].ToString(),
                        Team1Score = Int32.Parse(obj["scores"]["home"]["points"].ToString()),
                        Team2Score = Int32.Parse(obj["scores"]["visitors"]["points"].ToString()),
                        Logo1 = obj["teams"]["home"]["logo"].ToString(),
                        Logo2 = obj["teams"]["visitors"]["logo"].ToString(),
                        time = DateTime.Parse(obj["date"]["start"].ToString()),
                        Game=count

                    };
                    count++;
                    games.Add(gameInfo);
                }
              
                return games;
            }
            return null;

        }
    }
}