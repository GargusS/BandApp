using Microsoft.AspNetCore.Identity;

namespace BandApp.Models
{
  public class ApplicationUser : IdentityUser
  {
    // Denne linjen lagrer navnet til brukeren
    public string DisplayName { get; set; } = string.Empty;


    // Denne linjen lagrer filnavnet til profilbildet
    public string? ProfilePicture { get; set; }
  }
}
