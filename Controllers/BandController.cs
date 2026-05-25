using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BandApp.Data;
using BandApp.Models;
using System.Linq;

namespace BandApp.Controllers
{
  // Denne gjør at KUN innloggede brukere slipper inn på denne kontrolleren
  [Authorize]
  public class BandController : Controller
  {
    // Vi lager en intern merkelapp for databasen vår
    private readonly ApplicationDbContext _context;

    // Dette er den riktige konstruktøren for å ta imot databasetilgangen
    public BandController(ApplicationDbContext context)
    {
      _context = context;
    }

    public IActionResult Index()
    {
      return View();
    }
  }
}
