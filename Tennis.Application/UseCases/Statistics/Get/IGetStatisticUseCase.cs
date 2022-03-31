using Tennis.Entities;

namespace Tennis.Application.UseCases.Statistics.Get;

public interface IGetStatisticUseCase
{
    public (decimal averageImc, float medianHeight, Country? countryMaxwinrate) GetStatistics(int id);
}