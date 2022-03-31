using Tennis.Entities;

namespace Tennis.Application.UseCases.Players.Get;

public interface IGetPlayerUseCase
{ 
    Player GetPlayerById(int id); 
    List<Player> GetAllPlayers();
}