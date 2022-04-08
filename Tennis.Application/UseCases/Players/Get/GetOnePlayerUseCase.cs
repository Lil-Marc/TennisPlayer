using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tennis.Domain.Persistance.Players;
using Tennis.Entities;
using IOFile =System.IO.File;

namespace Tennis.Application.UseCases.Players.Get;

public class GetOnePlayerUseCase : IGetOnePlayerUseCase
{
    private readonly IPlayerReadRepository _readPlayers;
    private  IGetOnePlayerOutputPort? _outputPort;
    
    public GetOnePlayerUseCase(IPlayerReadRepository readPlayers)
    {
        _readPlayers = readPlayers;
    }
    
    public void SetOutputPort(IGetOnePlayerOutputPort outputPort)
    {
        _outputPort = outputPort;
    }

    public void Execute(int id)
    {
        var player = _readPlayers.GetPlayer(id);
        if (player is null)
        {
            _outputPort?.NotFound();
            return;
        }
        _outputPort?.Ok(player);
    }
    
}