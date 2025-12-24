using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BandApp.Models;
using System.Threading.Tasks;

namespace BandApp.Controllers
{
  [Authorize]
  public class MemberController : Controller
  {
    private readonly UserManager<ApplicationUser> _userManager;

    // UserManager for å hente profil-data
    public MemberController(UserManager<ApplicationUser> userManager)
    {
      _userManager = userManager;
    }

    public IActionResult Index()
    {
      return View();
    }

    // async for å kunne hente brukeren fra databasen
    public async Task<IActionResult> Profile()
    {
      var user = await _userManager.GetUserAsync(User);
      return View(user); // Sender bruker-objektet (med DisplayName og ProfilePicture) til visningen
    }
  }
}
