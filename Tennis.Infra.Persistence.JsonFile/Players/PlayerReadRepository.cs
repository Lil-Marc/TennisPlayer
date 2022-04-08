using Newtonsoft.Json;
using Tennis.Domain.Persistance.Players;
using Tennis.Entities;

namespace Tennis.Infra.Persistence.JsonFile.Players;

public class PlayerReadRepository: IPlayerReadRepository
{
    public PlayersCollection GetPlayers()
    {
        var text = File.ReadAllText("Data/Tennis_player.json");
        var players = JsonConvert.DeserializeObject<PlayersCollection>(text);
        return players;
    }

    public Player? GetPlayer(int id)
    {
        var players = GetPlayers();
        return players.Players.FirstOrDefault(p => p.Id == id);
    }
}