using Microsoft.AspNetCore.Identity;

namespace BandApp.Models
{
  public class ApplicationUser : IdentityUser
  {
    public string DisplayName { get; set; } = string.Empty;
  }
}
