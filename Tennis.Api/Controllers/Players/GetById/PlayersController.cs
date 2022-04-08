using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tennis.Application.UseCases.Players.Get;
using Tennis.Entities;
using IOFile =System.IO.File;

namespace Tennis.Controllers.Players.GetById;


[Route("api/[controller]")]
[ApiController]
public class PlayersController : ControllerBase, IGetOnePlayerOutputPort
{
    private IActionResult? _viewModel;
    void IGetOnePlayerOutputPort.NotFound() => _viewModel = NotFound(new ProblemDetails());
    void IGetOnePlayerOutputPort.Ok(Player player) => _viewModel = Ok(player);
    
    [HttpGet("{id:int}", Name = "Get player by Id")]
    public IActionResult GetPlayerById([FromServices] IGetOnePlayerUseCase useCase,[FromRoute] int id)
    {
        useCase.SetOutputPort(this);

        useCase.Execute(id);
        
        return _viewModel!;
    }
    
}