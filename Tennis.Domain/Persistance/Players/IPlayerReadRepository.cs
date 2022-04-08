using Tennis.Entities;

namespace Tennis.Domain.Persistance.Players;

public interface IPlayerReadRepository
{ 
    PlayersCollection GetPlayers();
    Player? GetPlayer(int id);
}