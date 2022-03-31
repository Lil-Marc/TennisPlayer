using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tennis.Entities;
using IOFile =System.IO.File;

namespace Tennis.Application.UseCases.Players.Get;

public class GetPlayerUseCase : IGetPlayerUseCase
{
    private static PlayersCollection GetPlayers()
    {
        var text = IOFile.ReadAllText("Data/Tennis_player.json");
        var players = JsonConvert.DeserializeObject<PlayersCollection>(text);
        return players;
    }

    public Player GetPlayerById(int id)
    {
        var players = GetPlayers();
        
        return players.Players.First(player => player.Id == id);
    }

    public List<Player> GetAllPlayers()
    {
        var players = GetPlayers().Players.OrderBy(player => player.Data.Rank).ToList();
        
        return players;
    }
}