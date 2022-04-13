using Tennis.Domain.Entities;

namespace Tennis.Application.UseCases.Players.GetAll;

public interface IGetAllPlayerOutputPort
{
    void Ok(IEnumerable<Player> players); 
    void NotFound();
}