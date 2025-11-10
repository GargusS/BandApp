namespace BandApp.Models
{
  public class BandMember
  {
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Role { get; set; } = "";
    public string Instrument { get; set; } = "";
    public string ImageUrl { get; set; } = "";
  }
}
