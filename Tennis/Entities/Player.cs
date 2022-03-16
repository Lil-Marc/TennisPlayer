namespace Tennis.Entities;


// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

public class Player
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Shortname { get; set; }
    public string Sex { get; set; }
    public Country Country { get; set; }
    public string Picture { get; set; }
    public Data Data { get; set; }
}