using Tennis.Domain.Persistance.Players;

namespace Tennis.Application.UseCases.Players.GetAll;

public class GetAllPlayerUseCase : IGetAllPlayerUseCase
{
    private readonly IPlayerReadRepository _readPlayers;
    private  IGetAllPlayerOutputPort? _outputPort;
    
    public GetAllPlayerUseCase(IPlayerReadRepository readPlayers)
    {
        _readPlayers = readPlayers;
    }
    
    public void SetOutputPort(IGetAllPlayerOutputPort outputPort)
    {
        _outputPort = outputPort;
    }

    public void Execute()
    {
        var players = _readPlayers.GetPlayers();
        if (players is null)
        {
            _outputPort?.NotFound();
            return;
        }

        var playersByOrder = players.Players.OrderBy(player => player.Data.Rank).ToList();
        _outputPort?.Ok(playersByOrder);
    }
}