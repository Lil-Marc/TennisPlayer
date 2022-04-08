using Tennis.Entities;

namespace Tennis.Application.UseCases.Statistics.Get;

public interface IGetStaticsOutputPort
{
    void Ok(string statistics); 
    void NotFound();
}