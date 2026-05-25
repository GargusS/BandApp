using System;

namespace BandApp.Models
{
  public class ChatMessage
  {
    public int Id { get; set; }
    public string SenderId { get; set; } = "";
    public string SenderName { get; set; } = "";
    public string Message { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // VIKTIG: Denne meldingen må tilhøre et spesifikt emne/tråd!
    // Databasen bruker dette tallet til å sortere meldingene i riktig tråd.
    public int TopicId { get; set; }
  }
}
