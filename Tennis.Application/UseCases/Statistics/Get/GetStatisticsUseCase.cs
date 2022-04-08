using Newtonsoft.Json;
using Tennis.Application.UseCases.Players.GetAll;
using Tennis.Domain.Persistance.Players;
using Tennis.Entities;

namespace Tennis.Application.UseCases.Statistics.Get;

public class GetStatisticsUseCase : IGetStatisticsUseCase
{
    private readonly IPlayerReadRepository _readPlayers;
    private  IGetStaticsOutputPort? _outputPort;
    
    public GetStatisticsUseCase(IPlayerReadRepository readPlayers)
    {
        _readPlayers = readPlayers;
    }
    
    public void SetOutputPort(IGetStaticsOutputPort outputPort)
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
        var averageIMC = players.Players.Average(player => player.GetIMC());
        var medianHeight = players.GetMedianHeight();
        var countryMaxwinrate =  players.Players
            .GroupBy(player => player.Country)
            .Select(grouping => new{Country = grouping.Key, winrate = grouping.Average(player => player.GetWinrate())})
            .MaxBy(arg => arg.winrate)
            ?.Country;
        
        var statics = new ValueTuple<decimal, float, Country?>(averageIMC, medianHeight, countryMaxwinrate);
        var json = JsonConvert.SerializeObject(statics);
        _outputPort?.Ok(json);
    }

}