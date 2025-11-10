using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BandApp.Models;

namespace BandApp.Data
{
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<ChatMessage> ChatMessages { get; set; } = null!;
    // Andre DbSet (Posts, Threads...) senere
  }
}
