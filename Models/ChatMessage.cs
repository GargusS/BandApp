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
  }
}
