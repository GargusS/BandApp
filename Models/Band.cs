using System;

namespace BandApp.Models
{
  public class Band
  {
    // Databasen bruker denne til å gi hvert band et unikt nummer (1, 2, 3 osv.)
    public int Id { get; set; }

    // Navnet på bandet (f.eks. "Rockebandet AS")
    public string Name { get; set; } = "";

    // Her lagrer vi Identity-brukerID-en til den som opprettet bandet.
    // Det er denne ID-en vi skal sjekke etterpå for å gi sletterettigheter!
    public string AdminId { get; set; } = "";

    // Når bandet ble opprettet i systemet
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  }
}
