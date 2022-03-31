using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Tennis.Application.UseCases.Players.Get;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// builder.Services.AddRouting();

builder.Services.AddTransient<IGetPlayerUseCase,GetPlayerUseCase>();



var app = builder.Build();


app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });


app.Run();