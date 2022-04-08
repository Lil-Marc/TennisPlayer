using Tennis.Entities;

namespace Tennis.Application.UseCases.Players.Get;

public interface IGetOnePlayerUseCase
{
    void SetOutputPort(IGetOnePlayerOutputPort outputPort);
    void Execute(int id);
}