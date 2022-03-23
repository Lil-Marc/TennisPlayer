using Newtonsoft.Json;
using Tennis.Entities;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

static PlayersCollection GetPlayers()
{
    var text = File.ReadAllText("Data/Tennis_player.json");
    var players = JsonConvert.DeserializeObject<PlayersCollection>(text);
    return players;
}

static float GetWinrate(Player player)
{
    var victoryCount = player.Data.Last.Sum();
    
    var winrate = victoryCount/player.Data.Last.Count;
    
    return winrate;
}

static float GetMedianHeight(PlayersCollection players)
{
    //pair
    if (players.Players.Count % 2 == 0)
    {
        return (
                (players.Players.ElementAt(((players.Players.Count) / 2) - 1).Data.Height)
                + 
                (players.Players.ElementAt(((players.Players.Count) / 2)).Data.Height)
                ) / 2f;
    }

    //impair
    return players.Players.ElementAt(((players.Players.Count - 1) / 2) ).Data.Height;
    
}

static decimal GetIMC(Player player)
{
    var weight = player.Data.Weight / 1000m;
    var height = player.Data.Height / 100m;
    
    var imc = weight  / (height * height);
    
    return imc;
}

app.MapGet("/players", () =>
{
    var players = GetPlayers();
    return players.Players.OrderBy(player => player.Data.Rank);
});


app.MapGet("/players/{id:int}", ( int id) =>
{
    var players = GetPlayers();
    return players.Players.First(player => player.Id == id);
});

app.MapGet("/players/statistics", () =>
{
    var players = GetPlayers();
    
    var averageIMC = players.Players.Average(GetIMC);
    var medianHeight = GetMedianHeight(players);
    var countryMaxwinrate =  players.Players
        .GroupBy(player => player.Country)
        .Select(grouping => new{Country = grouping.Key, winrate = grouping.Average(GetWinrate)})
        .MaxBy(arg => arg.winrate)
        ?.Country;
 
    
    return new {averageIMC,medianHeight,countryMaxwinrate};
});


app.Run();