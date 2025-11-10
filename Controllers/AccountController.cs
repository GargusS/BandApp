using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BandApp.Models;

namespace BandApp.Controllers;

public class AccountController : Controller
{
  private readonly UserManager<ApplicationUser> _userManager;
  private readonly SignInManager<ApplicationUser> _signInManager;

  public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
  {
    _userManager = userManager;
    _signInManager = signInManager;
  }

  [HttpGet]
  public IActionResult Register() => View();

  [HttpPost]
  public async Task<IActionResult> Register(RegisterViewModel vm)
  {
    if (!ModelState.IsValid) return View(vm);
    var user = new ApplicationUser { UserName = vm.Email, Email = vm.Email, DisplayName = vm.DisplayName };
    var result = await _userManager.CreateAsync(user, vm.Password);
    if (result.Succeeded)
    {
      await _signInManager.SignInAsync(user, isPersistent: false);
      return RedirectToAction("Index", "Home");
    }
    foreach (var e in result.Errors) ModelState.AddModelError("", e.Description);
    return View(vm);
  }

  [HttpGet]
  public IActionResult Login(string? returnUrl = null) => View(new LoginViewModel { });

  [HttpPost]
  public async Task<IActionResult> Login(LoginViewModel vm, string? returnUrl = null)
  {
    if (!ModelState.IsValid) return View(vm);
    var result = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, vm.RememberMe, lockoutOnFailure: false);
    if (result.Succeeded) return LocalRedirect(returnUrl ?? "/");
    ModelState.AddModelError("", "Invalid login attempt");
    return View(vm);
  }

  [HttpPost]
  public async Task<IActionResult> Logout()
  {
    await _signInManager.SignOutAsync();
    return RedirectToAction("Index", "Home");
  }
}
