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
	public class TreatsController : Controller
	{
		private readonly PierreTreatsContext _db;
		private readonly UserManager<ApplicationUser> _userManager;
		public TreatsController(UserManager<ApplicationUser> userManager, PierreTreatsContext db)
		{
			_db = db;
			_userManager = userManager;
		}

		public ActionResult Index(string sortOrder)
		{
			switch (sortOrder)
			{
				case "priceAsc":
					var treatsPriceAsc = _db.Treats.OrderBy(t => t.Price).ToList();
					return View(userTreatsPriceAsc);
				case "priceDesc":
					var treatsPriceDesc = _db.Treats.OrderByDescending(t => t.Price).ToList();
					return View(userTreatsPriceDesc);
				default:
					var Treats = _db.Treats.OrderBy(t => t.Name).ToList();
					return View(userTreats);
			}
		}

		public ActionResult Create()
		{
			ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name")
			return View();
		}

		[HttpPost]
		public ActionResult Create(Treat treat, int FlavorId)
		{
			_db.Treats.Add(treat);
			_db.SaveChanges();
			if (FlavorId != 0)
			{
				_db.TreatFlavor.Add(new TreatFlavor() {TreatId = treat.TreatId, FlavorId = FlavorId});
				_db.SaveChanges();
			}
			return RedirectToAction("Details", new{id = treat.TreatId})
		}

		public ActionResult Details(int id)
		{
			
		}
	}
}
