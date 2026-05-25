using System;

namespace BandApp.Models
{
  public class ChatTopic
  {
    // Unikt nummer for akkurat dette emnet/tråden
    public int Id { get; set; }

    // Navnet på emnet (f.eks. "Generelt", "Bookinger", "Låter")
    public string Name { get; set; } = "";

    // En valgfri beskrivelse av hva man prater om her
    public string Description { get; set; } = "";

    // VIKTIG: Dette emnet må tilhøre et bestemt band!
    public int BandId { get; set; }

    // Her lagrer vi hvem som opprettet emnet (valgfritt, men kjekt for historikk)
    public string CreatedById { get; set; } = "";

    // Når emnet ble opprettet
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  }
}
