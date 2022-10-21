using System;
using Microsoft.AspNetCore.Authorization;

namespace PierreTreats.ViewModels
{
	[AllowAnonymous]
	public class LoginViewModel
	{
		public string UserName {get; set;}
		public string Password {get; set;}
	}
}