using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tennis.Application.UseCases.Players.Get;
using Tennis.Entities;
using IOFile =System.IO.File;

namespace Tennis.Controllers.Players.GetById;


[Route("api/[controller]")]
[ApiController]
public class PlayersController : ControllerBase
{
    [HttpGet("{id:int}", Name = "Get player by Id")]
    public IActionResult GetPlayerById([FromServices] IGetPlayerUseCase useCase,[FromRoute] int id)
    {

        return Ok(useCase.GetPlayerById(id));
    }
    
}