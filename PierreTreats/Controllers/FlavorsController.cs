using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PierreTreats.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace PierreTreats.Controllers
{
	[Authorize]
	public class FlavorsController : Controller
	{
		private readonly PierreTreatsContext _db;
		private readonly UserManager<ApplicationUser> _userManager;

		public FlavorsController(UserManager<ApplicationUser> userManager, PierreTreatsContext db)
		{
			_db = db;
			_userManager = userManager;
		}

		public ActionResult Index()
		{
			return View(_db.Flavors.ToList());
		}

		[Authorize(Roles="Admin")]
		public ActionResult Create()
		{
			return View();
		}

		[Authorize(Roles="Admin")]
		[HttpPost]
		public ActionResult Create(Flavor flavor)
		{
			_db.Flavors.Add(flavor);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Details(int id)
		{
			Flavor thisFlavor = _db.Flavors
				.Include(f => f.JoinTreFla)
				.ThenInclude(join => join.Flavor)
				.FirstOrDefault(f => f.FlavorId == id);
			return View(thisFlavor);
		}

		[Authorize(Roles="Admin")]
		[HttpPost]
		public ActionResult Delete(int id)
		{
			Flavor thisFlavor = _db.Flavors.FirstOrDefault(f => f.FlavorId == id);
			_db.Flavors.Remove(thisFlavor);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}