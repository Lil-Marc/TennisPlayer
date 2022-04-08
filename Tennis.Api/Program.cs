using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Tennis.Application.UseCases.Players.Get;
using Tennis.Application.UseCases.Players.GetAll;
using Tennis.Application.UseCases.Statistics.Get;
using Tennis.Domain.Persistance.Players;
using Tennis.Infra.Persistence.JsonFile.Players;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();



builder.Services.AddTransient<IGetOnePlayerUseCase,GetOnePlayerUseCase>();
builder.Services.AddTransient<IGetAllPlayerUseCase,GetAllPlayerUseCase>();
builder.Services.AddTransient<IPlayerReadRepository,PlayerReadRepository>();
builder.Services.AddTransient<IGetStatisticsUseCase,GetStatisticsUseCase>();



var app = builder.Build();


app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });


app.Run();