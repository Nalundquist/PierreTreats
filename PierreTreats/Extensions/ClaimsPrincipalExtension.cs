using System.Linq;
using System.Security.Claims;

namespace PierreTreats.Extensions
{
	public static class ClaimsPrincipalExtension
	{
		public static string GetEmail(this ClaimsPrincipal principal)
		{
			var email = principal.Claims.FirstOrDefault(c => c.Type == "Email");
			return email?.Value;
		}

		public static string GetFirstName(this ClaimsPrincipal principal)
		{
			var firstName = principal.Claims.FirstOrDefault(c => c.Type == "FirstName");
			return firstName?.Value;
		}

		public static string GetLastName(this ClaimsPrincipal principal)
		{
			var lastName = principal.Claims.FirstOrDefault(c => c.Type == "LastName");
			return lastName?.Value;
		}

		public static string GetFavFood(this ClaimsPrincipal principal)
		{
			var favFood = principal.Claims.FirstOrDefault(c => c.Type == "FavFood");
			return favFood?.Value;
		}
	}
}