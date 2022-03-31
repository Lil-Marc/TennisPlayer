using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tennis.Application.UseCases.Players.Get;
using Tennis.Entities;


namespace Tennis.Controllers.Players.GetAll;

[Route("api/[controller]")]
[ApiController]
public class PlayersController : ControllerBase
{

    [HttpGet(Name = "Get all players")]
    public IActionResult GetAllPlayers([FromServices] IGetPlayerUseCase useCase)
    {
        return Ok(useCase.GetAllPlayers());
    }
}