using Tennis.Domain.Common;

namespace Tennis.Domain.Entities;

public class PlayersCollection
{
    public PlayersCollection(List<Player> players)
    {
        Players = players;
    }

    public List<Player> Players { get; }
    public float GetMedianHeight()
    {
        if (Players.Count == 0)
            return 0;

        var orderedPlayer = Players.OrderBy(x => x.Data.Height).ToList();
        //pair
        if (orderedPlayer.Count % 2 == 0)
        {
            return (
                orderedPlayer.ElementAt(orderedPlayer.Count / 2 - 1).Data.Height
                + 
                orderedPlayer.ElementAt(orderedPlayer.Count / 2).Data.Height
            ) / 2f;
        }

        //impair
        return orderedPlayer.ElementAt((orderedPlayer.Count - 1) / 2 ).Data.Height;
    }

    public decimal GetAverageIMC() => Players.AverageOrZero(player => player.GetIMC());
}