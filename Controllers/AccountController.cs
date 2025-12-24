using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BandApp.Models;
using BandApp.ViewModels;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace BandApp.Controllers
{
  public class AccountController : Controller
  {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public AccountController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IWebHostEnvironment webHostEnvironment)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _webHostEnvironment = webHostEnvironment;
    }

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
      if (!ModelState.IsValid) return View(model);

      var user = new ApplicationUser
      {
        UserName = model.Email,
        Email = model.Email,
        DisplayName = model.DisplayName
      };

      var result = await _userManager.CreateAsync(user, model.Password);

      if (result.Succeeded)
      {
        await _signInManager.SignInAsync(user, isPersistent: false);
        return RedirectToAction("Index", "Member");
      }

      foreach (var error in result.Errors)
        ModelState.AddModelError("", error.Description);

      return View(model);
    }

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
      if (!ModelState.IsValid) return View(model);

      var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

      if (result.Succeeded)
      {
        return RedirectToAction("Index", "Member");
      }

      ModelState.AddModelError("", "Ugyldig innloggingsforsøk.");
      return View(model);
    }


    [HttpPost]
    public async Task<IActionResult> Logout()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<IActionResult> UpdateProfile(IFormFile imageFile)
    {
      var user = await _userManager.GetUserAsync(User);
      if (user == null || imageFile == null || imageFile.Length == 0) return RedirectToAction("Profile", "Member");

      string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img", "profiles");
      if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

      // --- 1. SLETT GAMMELT BILDE HVIS DET EKSISTERER ---
      if (!string.IsNullOrEmpty(user.ProfilePicture))
      {
        string oldFilePath = Path.Combine(uploadsFolder, user.ProfilePicture);
        if (System.IO.File.Exists(oldFilePath))
        {
          System.IO.File.Delete(oldFilePath);
        }
      }

      // --- 2. BEHANDLE OG LAGRE NYTT BILDE ---
      string uniqueFileName = Guid.NewGuid().ToString() + ".jpg";
      string filePath = Path.Combine(uploadsFolder, uniqueFileName);

      using (var image = await Image.LoadAsync(imageFile.OpenReadStream()))
      {
        image.Mutate(x => x.Resize(new ResizeOptions
        {
          Size = new Size(300, 300),
          Mode = ResizeMode.Crop
        }));
        await image.SaveAsJpegAsync(filePath);
      }

      // --- 3. OPPDATER DATABASE ---
      user.ProfilePicture = uniqueFileName;
      await _userManager.UpdateAsync(user);

      return RedirectToAction("Profile", "Member");
    }
  }
}
