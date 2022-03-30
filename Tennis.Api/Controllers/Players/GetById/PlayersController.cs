using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tennis.Entities;
using IOFile =System.IO.File;

namespace Tennis.Controllers.Players.GetById;


[Route("api/[controller]")]
[ApiController]
public class PlayersController : ControllerBase
{
    static PlayersCollection GetPlayers()
    {
        var text = IOFile.ReadAllText("Data/Tennis_player.json");
        var players = JsonConvert.DeserializeObject<PlayersCollection>(text);
        return players;
    }
    
    [HttpGet("{id:int}", Name = "Get player by Id")]
    public IActionResult GetPlayerById([FromRoute] int id)
    {
        var players = GetPlayers();
        
        return Ok(players.Players.First(player => player.Id == id));
    }
}