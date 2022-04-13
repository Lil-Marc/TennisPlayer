namespace Tennis.Application.UseCases.Players.GetAll;

public interface IGetAllPlayerUseCase
{ 
    void SetOutputPort(IGetAllPlayerOutputPort outputPort);
    void Execute();
}