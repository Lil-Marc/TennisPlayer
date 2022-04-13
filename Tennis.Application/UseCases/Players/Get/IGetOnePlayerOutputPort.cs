using Tennis.Domain.Entities;

namespace Tennis.Application.UseCases.Players.Get;

public interface IGetOnePlayerOutputPort
{
    void Ok(Player playerById); 
    void NotFound();
}