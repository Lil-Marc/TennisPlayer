using System.Collections.Generic;

namespace Tennis.Entities;

public class PlayersCollection
{
    public PlayersCollection()
    {
    }

    public PlayersCollection(List<Player?> players)
    {
        Players = players;
    }

    public List<Player?> Players { get; set; }
    public float GetMedianHeight()
    {
        //pair
        if (this.Players.Count % 2 == 0)
        {
            return (
                (this.Players.ElementAt(((this.Players.Count) / 2) - 1).Data.Height)
                + 
                (this.Players.ElementAt(((this.Players.Count) / 2)).Data.Height)
            ) / 2f;
        }

        //impair
        return this.Players.ElementAt(((this.Players.Count - 1) / 2) ).Data.Height;
    }
}