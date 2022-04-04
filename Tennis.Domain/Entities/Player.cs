namespace Tennis.Entities;


// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

public class Player
{
    public Player()
    {
        Data = new Data();
    }

    public Player(int id, string firstname, string lastname, string shortname, string sex, Country country, string picture, Data data)
    {
        Id = id;
        Firstname = firstname;
        Lastname = lastname;
        Shortname = shortname;
        Sex = sex;
        Country = country;
        Picture = picture;
        Data = data;
    }


    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Shortname { get; set; }
    public string Sex { get; set; }
    public Country Country { get; set; }
    public string Picture { get; set; }
    public Data Data { get; set; }
    
    public decimal GetIMC()
    {
        var weight = this.Data.Weight / 1000m;
        var height = this.Data.Height / 100m;
    
        var imc = weight  / (height * height);
    
        return imc;
    }
    public float GetWinrate()
    {
        var victoryCount = this.Data.Last.Sum();
    
        float winrate = victoryCount/(float)this.Data.Last.Count;
    
        return winrate;
    }
}