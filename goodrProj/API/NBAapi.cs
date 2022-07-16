using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccessLibrary;
using DataAccessLibrary.Model;

namespace goodrProj.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NBAapi : ControllerBase
    {
        APIcall APIcall =new APIcall();
        private List<GameInfo>? gamesInfo;
        public async Task<List<GameInfo>> games()
        {
            gamesInfo = await APIcall.Call(1, 2, 2021);
            return gamesInfo;
        }
    }
}
