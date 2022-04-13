using System.Collections.Generic;
using System.Linq;
using Tennis.Domain.Entities;
using Xunit;

namespace Tennis.Domain.Test;

public class PlayerCollectionTest
{
    [Theory]
    [InlineData(new[]{0,0,0},0)]
    [InlineData(new[]{1,2,3},2)]
    [InlineData(new[]{170,175,180},175)]
    [InlineData(new[]{170},170)]
    [InlineData(new[]{170, 171},170.5)]
    [InlineData(new[]{180, 170, 175}, 175)]
    [InlineData(new int[0], 0)]
    public void Given_PlayerCollection_Then_MedianHeightShouldBeCorrect(int[] heights,float res)
    {
        //arrange
        var players = heights.Select(height => new Player
        {
            Data = new Data(65000, height)
        }).ToList();

        var playersCollection = new PlayersCollection(players);

        var medianHeight = playersCollection.GetMedianHeight();
        
        //assert
        Assert.Equal(res,medianHeight);
    }
    
    [Fact]
    public void Given_Empty_PlayerCollection_Then_AverageIMCShouldBeCorrect()
    {
        //arrange

        var playersCollection = new PlayersCollection(new List<Player>());

        var medianHeight = playersCollection.GetAverageIMC();
        
        //assert
        Assert.Equal(0,medianHeight);
    }
}