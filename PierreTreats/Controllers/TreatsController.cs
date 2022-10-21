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
					return View(treatsPriceAsc);
				case "priceDesc":
					var treatsPriceDesc = _db.Treats.OrderByDescending(t => t.Price).ToList();
					return View(treatsPriceDesc);
				default:
					var treats = _db.Treats.OrderBy(t => t.Name).ToList();
					return View(treats);
			}
		}

		public ActionResult Create()
		{
			ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
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
			return RedirectToAction("Details", new{id = treat.TreatId});
		}

		public ActionResult Details(int id)
		{
			Treat thisTreat = _db.Treats
				.Include(t => t.JoinTreFla)
				.ThenInclude(join => join.Treat)
				.FirstOrDefault(t => t.TreatId == id);
			return View(thisTreat);
		}

		public ActionResult Edit(int id)
		{
			Treat thisTreat = _db.Treats.FirstOrDefault(t => t.TreatId == id);
			ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
			return View(thisTreat);
		}

		[HttpPost]
		public ActionResult Edit(Treat treat, int FlavorId)
		{
			_db.Entry(treat).State = EntityState.Modified;
			_db.SaveChanges();
			foreach (TreatFlavor join in _db.TreatFlavor)
			{
				if(treat.TreatId == join.TreatId && FlavorId == join.FlavorId)
				{
					return RedirectToAction("Details", new {id = treat.TreatId});
				}
			}
			if (FlavorId != 0)
			{
				_db.TreatFlavor.Add(new TreatFlavor() {TreatId = treat.TreatId, FlavorId = FlavorId});
				_db.SaveChanges();
			}
			return RedirectToAction("Details", new {id=treat.TreatId});
		}

		[HttpPost]
		public ActionResult Delete(int id)
		{
			Treat thisTreat = _db.Treats.FirstOrDefault(t => t.TreatId == id);
			_db.Treats.Remove(thisTreat);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult DeleteFlavor(int joinId, int treatId)
		{
			TreatFlavor join = _db.TreatFlavor.FirstOrDefault(j => j.TreatFlavorId == joinId);
			_db.TreatFlavor.Remove(join);
			_db.SaveChanges();
			return RedirectToAction("Details", new{id=treatId});
		}
	}
}
