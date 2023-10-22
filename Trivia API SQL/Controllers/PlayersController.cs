using Microsoft.AspNetCore.Mvc;
using Trivia_API_SQL.Controllers;

namespace TriviaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        [HttpGet("Get/{id}")]
        public string Get(int id)
        {
            DBHandler dBHandler = new DBHandler();
            return dBHandler.GetPlayerName(id);
        }

        [HttpGet("GetAns/{questionID}")]
        public string GetAns(int questionID)
        {
            DBHandler dBHandler = new DBHandler();
            return dBHandler.GetCurrectAns(questionID);
        }
        [HttpGet("GetFinish/{id}")]
        public string GetFinish(int id)
        {
            DBHandler dBHandler = new DBHandler();
            return dBHandler.GetPlayerFinish(id);
        }

        [HttpGet("GetScore/{id}")]
        public string GetPlayerScore(int id)
        {
            DBHandler dBHandler = new DBHandler();
            return dBHandler.GetScore(id);
        }

        [HttpPost("ChangeName")]
        public void ChangeName([FromForm] ChangePlayersName playerName)
        {
            string name = playerName.Name;
            int ID = playerName.id;
            DBHandler dBHandler = new DBHandler();
            dBHandler.AddPlayer(name, ID);
        }

        [HttpPost("ChangeReady")]
        public void ChangeReady([FromForm] Ready playerReady)
        {
            string ready = playerReady.PlayerIsReady;
            DBHandler dBHandler = new DBHandler();
            dBHandler.PlayerReady(ready);
        }
        [HttpPost("ChangeScore")]
        public void ChangeScore([FromForm] ChangePlayerScore score)
        {
            string Player_Score = score.PlayerScore;
            int ID = score.id;
            DBHandler dBHandler = new DBHandler();
            dBHandler.SetScore(Player_Score, ID);
        }
        [HttpPost("PlayerFinish")]
        public void PlayerFinish([FromForm] Finish finish)
        {
            string Player_Finished = finish.PlayerFinished;
            int ID = finish.id;
            DBHandler dBHandler = new DBHandler();
            dBHandler.Finish(Player_Finished, ID);
        }
        
        
    }
}