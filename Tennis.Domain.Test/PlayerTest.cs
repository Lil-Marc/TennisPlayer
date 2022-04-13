using System.Collections.Generic;
using Tennis.Domain.Entities;
using Xunit;

namespace Tennis.Domain.Test;

public class PlayerTest
{
    [Fact]
    public void Given_PlayerHeightIs180WeightIs75kg_Then_IMCShouldBeEquals23Point1()
    {
        //arrange
        var player_185_75 = new Player();
        var data = new Data(75000,180);
        player_185_75.Data = data;
        
        //assert
        Assert.Equal(23.1m,player_185_75.GetIMC(),1);
    }
    
    [Fact]
    public void Given_PlayerHeightIs180WeightIs75_Then_IMCShouldBeEquals23Point1_2()
    {
        //arrange
        var player_185_75 = new Player();
        var data = new Data(75000,180);
        player_185_75.Data = data;
        
        //assert
        Assert.Equal(23.2m, player_185_75.GetIMC(), 0);
    }
    
    
    [Fact]
    public void Given_PlayerWin2Lost3_Then_WinRateShouldBe40Percent()
    {
        //arrange
        var player = new Player();
        player.Data.Last = new List<int>() {1, 1, 0, 0, 0};
        
        //assert
        Assert.Equal(0.4, player.GetWinrate(),1);
    }
    

}