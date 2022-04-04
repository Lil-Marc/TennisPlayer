using System.Collections.Generic;

namespace Tennis.Entities;

public class Data
{
    public int Rank { get; set; }
    public int Points { get; set; }
    public int Weight { get; set; }
    public int Height { get; set; }
    public int Age { get; set; }
    public List<int> Last { get; set; }

    public Data()
    {
        Last = new List<int>();
    }

    public Data(int rank, int points, int weight, int height, int age) : this(weight,height)
    {
        Rank = rank;
        Points = points;
        Age = age;
        

    }
    public Data(int weight, int height) : this()
    {
        Weight = weight;
        Height = height;
    }
}



