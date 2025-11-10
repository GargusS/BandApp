using Microsoft.AspNetCore.Mvc;
using BandApp.Models;

namespace BandApp.Controllers
{
  public class BandController : Controller
  {
    public IActionResult Index()
    {
      var members = new List<BandMember>
            {
                new BandMember { Id = 1, Name = "Argus", Role = "Gitar & vokal", ImageUrl = "/img/argus.jpg" },
                new BandMember { Id = 2, Name = "Toke", Role = "Trommer", ImageUrl = "/img/argus.jpg" },
                new BandMember { Id = 3, Name = "Vegar", Role = "Bass", ImageUrl = "/img/argus.jpg" },
                new BandMember { Id = 4, Name = "Tom-H", Role = "Vokal", ImageUrl = "/img/argus.jpg" }
            };
      return View(members);
    }
  }
}
