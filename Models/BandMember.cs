namespace BandApp.Models
{
  public class BandMember
  {
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Role { get; set; } = "";
    public string Instrument { get; set; } = "";
    public string ImageUrl { get; set; } = "";

    // 1. Kobling til den ekte brukerkontoen i .NET Identity (Bruker-ID-en)
    public string UserId { get; set; } = "";

    // 2. Kobling til det spesifikke bandet medlemmet tilhører (Band-ID-en)
    public int BandId { get; set; }
  }
}
