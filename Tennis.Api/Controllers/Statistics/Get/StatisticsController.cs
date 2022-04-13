using Microsoft.AspNetCore.Mvc;
using Tennis.Application.UseCases.Statistics.Get;

namespace Tennis.Controllers.Statistics.Get;

[Route("api/[controller]")]
[ApiController]
public class StatisticsController : ControllerBase, IGetStaticsOutputPort
{
    
    private IActionResult? _viewModel;
    void IGetStaticsOutputPort.NotFound() => _viewModel = NotFound(new ProblemDetails());
    void IGetStaticsOutputPort.Ok(string statistics) => _viewModel = Ok(statistics);

    [HttpGet(Name = "Get statistics")]
    public IActionResult GetStatistics([FromServices] IGetStatisticsUseCase useCase)
    {
        useCase.SetOutputPort(this);
        useCase.Execute();
        return _viewModel!;
    }
}