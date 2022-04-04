using Newtonsoft.Json;
using Tennis.Entities;

namespace Tennis.Application.UseCases.Statistics.Get;

public class GetStatisticUseCase : IGetStatisticUseCase
{
    static PlayersCollection GetPlayers()
    {
        var text = System.IO.File.ReadAllText("Data/Tennis_player.json");
        var players = JsonConvert.DeserializeObject<PlayersCollection>(text);
        return players;
    }
    

    public (decimal averageImc, float medianHeight, Country? countryMaxwinrate) GetStatistics(int id)
    {
        var players = GetPlayers();
    
        var averageIMC = players.Players.Average(player => player.GetIMC());
        var medianHeight = players.GetMedianHeight();
        var countryMaxwinrate =  players.Players
            .GroupBy(player => player.Country)
            .Select(grouping => new{Country = grouping.Key, winrate = grouping.Average(player => player.GetWinrate())})
            .MaxBy(arg => arg.winrate)
            ?.Country;

        return new ValueTuple<decimal, float, Country?>(averageIMC, medianHeight, countryMaxwinrate);
    }
    
}