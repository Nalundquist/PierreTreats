using PierreTreats.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace PierreTreats.Authorization
{
	public class PierreUserAuthorizationHandler : AuthorizationHander<OperationAuthorizationRequirement, Treat, Flavor, TreatFlavor>
	{
		UserManager<IdentityUser> _userManager;

		public PierreUserAuthorizationHandler(UserManager<IdentityUser> userManager)
		{
			_userManager = userManager;
		}

		protected override Task
			HandleRequirementAsync(AuthorizationHandlerContext context
														OperationAuthorizationRequirement requirement
														Contact resource)
			{
				if (context.User == null || resource.User == null)
				{
					return Task.CompletedTask;
				}
			}
	}
}