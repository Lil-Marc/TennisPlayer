namespace Tennis.Application.UseCases.Statistics.Get;

public interface IGetStatisticsUseCase
{
    void SetOutputPort(IGetStaticsOutputPort outputPort);
    void Execute();
}