using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BandApp.Models;

namespace BandApp.Data
{
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<ChatMessage> ChatMessages { get; set; } = null!;

    // Her registreres de nye tabellene:
    public DbSet<Band> Bands { get; set; } = null!;
    public DbSet<BandMember> BandMembers { get; set; } = null!;
    public DbSet<ChatTopic> ChatTopics { get; set; } = null!;
  }
}
