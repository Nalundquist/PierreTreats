using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PierreTreats.Models;
using System.Threading.Tasks;
using PierreTreats.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System;

namespace PierreTreats.Controllers
{
	public class AccountController : Controller
	{
		private readonly PierreTreatsContext _db;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, PierreTreatsContext db)
		{
			_db = db;
			_signInManager = signInManager;
			_userManager = userManager;
		}

		public ActionResult Index()
		{
			return View();
		}

		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> Register (RegisterViewModel model)
		{
			var user = new ApplicationUser {UserName = model.UserName, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, FavFood = model.FavFood};
			IdentityResult result = await _userManager.CreateAsync(user, model.Password);
			if (result.Succeeded)
			{
				await _userManager.AddClaimAsync(user, new Claim("Email", user.Email));
				await _userManager.AddClaimAsync(user, new Claim("FirstName", user.FirstName));
				await _userManager.AddClaimAsync(user, new Claim("LastName", user.LastName));
				if (user.FavFood != null)
				{
					await _userManager.AddClaimAsync(user, new Claim("FavFood", user.FavFood));
				}
				await _signInManager.SignInAsync(user, isPersistent: true);
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.RegistrationFailed = "Registration Failed, please try again.";
				return View();
			}
		}

		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> Login(LoginViewModel model)
		{
			Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: true, lockoutOnFailure: false);
			if (result.Succeeded)
			{
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.LoginFailed = "Login Failed, please try again.";
				return View();
			}
		}

		[HttpPost]
		public async Task<ActionResult> Logoff()
		{
			await _signInManager.SignOutAsync();
			ViewBag.LogOutSuccess = "You have logged out.";
			return RedirectToAction("Index");
		}
	}
}