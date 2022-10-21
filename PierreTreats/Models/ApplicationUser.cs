using Microsoft.AspNetCore.Identity;
using System;

namespace PierreTreats.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName {get; set;}
		public string LastName {get; set;}
		public string FavFood {get; set;}
	}
}