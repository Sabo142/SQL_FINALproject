using Microsoft.AspNetCore.Mvc;
namespace TriviaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        [HttpGet("{id}")]
        public Question Get(int id)
        {
            DBHandler dBHandler = new DBHandler();
            return dBHandler.GetQuestion(id);
        }
    }
}
