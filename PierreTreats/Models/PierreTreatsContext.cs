using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PierreTreats.Models
{
	public class PierreTreatsContext : IdentityDbContext<ApplicationUser>
	{
		public DbSet<Treat> Treats {get; set;}
		public DbSet<Flavor> Flavors {get; set;}
		public DbSet<TreatFlavor> TreatFlavor {get; set;}

		public PierreTreatsContext (DbContextOptions options) : base(options) {}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies();
		}
	}
}