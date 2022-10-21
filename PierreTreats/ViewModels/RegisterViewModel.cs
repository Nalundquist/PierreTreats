using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Authorization;

namespace PierreTreats.ViewModels
{
	[AllowAnonymous]
	public class RegisterViewModel
	{
		[Required]
		[Display(Name = "User Name")]
		public string UserName {get; set;}

		[Required]
		[EmailAddress]
		[Display(Name = "Email Address")]
		public string Email {get; set;}
		
		[Required]
		[DataType(DataType.Text)]
		[Display(Name = "First Name")]
		public string FirstName {get; set;}

		[Required]
		[DataType(DataType.Text)]
		[Display(Name = "Last Name")]
		public string LastName {get; set;}

		[DataType(DataType.Text)]
		[Display(Name = "Favorite Food")]
		public string FavFood {get; set;}

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password {get; set;}
		
		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Confirm Password")]
		public string ConfirmPassword {get; set;}
	}
}