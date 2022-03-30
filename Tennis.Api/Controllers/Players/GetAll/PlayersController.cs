using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tennis.Entities;

namespace Tennis.Controllers.Players.GetAll;

[Route("api/[controller]")]
[ApiController]
public class PlayersController : ControllerBase
{
    static PlayersCollection GetPlayers()
    {
        var text = System.IO.File.ReadAllText("Data/Tennis_player.json");
        var players = JsonConvert.DeserializeObject<PlayersCollection>(text);
        return players;
    }
    
    [HttpGet(Name = "Get all players")]
    public IActionResult GetAllPlayers()
    {
        var players = GetPlayers();
        return Ok(players.Players.OrderBy(player => player.Data.Rank));
    }
}