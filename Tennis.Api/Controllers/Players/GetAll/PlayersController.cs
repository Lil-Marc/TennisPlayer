using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tennis.Application.UseCases.Players.Get;
using Tennis.Application.UseCases.Players.GetAll;
using Tennis.Entities;


namespace Tennis.Controllers.Players.GetAll;

[Route("api/[controller]")]
[ApiController]
public class PlayersController : ControllerBase, IGetAllPlayerOutputPort
{
    private IActionResult? _viewModel;
    void IGetAllPlayerOutputPort.NotFound() => _viewModel = NotFound(new ProblemDetails());
    void IGetAllPlayerOutputPort.Ok(IEnumerable<Player> playersByOrder) => _viewModel = Ok(playersByOrder);
    [HttpGet(Name = "Get all players")]
    public IActionResult GetAllPlayers([FromServices] IGetAllPlayerUseCase useCase)
    {
        useCase.SetOutputPort(this);

        useCase.Execute();
        
        return _viewModel!;
        
    }
}
