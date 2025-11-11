using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BandApp.Controllers
{
  [Authorize] // <--- Denne linjen gjør at siden vises kun for medlemmer
  public class MemberController : Controller
  {
    // Alle actions (metoder) i denne kontrolleren krever innlogging
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Profile()
    {
      return View();
    }
  }
}