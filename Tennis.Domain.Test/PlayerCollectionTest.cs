using System.Collections.Generic;
using System.Linq;
using Tennis.Entities;
using Xunit;

namespace Tennis.Domain.Test;

public class PlayerCollectionTest
{
    [Theory]
    [InlineData(new int[]{0,0,0},0)]
    [InlineData(new int[]{1,2,3},2)]
    [InlineData(new int[]{170,175,180},175)]
    public void Given_PlayerCollection_Then_MedianHeightShouldBeCorrect(int[] heights,float res)
    {
        //arrange
        var players = heights.Select(height => new Player()
        {
            Data = new Data(65000, height)
        }).ToList();

        var playersCollection = new PlayersCollection(players);

        var MedianHeight = playersCollection.GetMedianHeight();
        
        //assert
        Assert.Equal(MedianHeight,res);
    }
    
    
    
}