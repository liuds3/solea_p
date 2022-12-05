using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// Model for 'Marke' entity.
	/// </summary>
	public class UserListVM
	{
		[DisplayName("Id")]
		public int Id { get; set; }

		[DisplayName("Name")]
		[Required]
		public string Name { get; set; }

		[DisplayName("Currency")]
		public int Currency { get; set; }

		[DisplayName("Email")]
		[Required]
		public string Email { get; set; }

		[DisplayName("Password")]
		[Required]
		public string Password { get; set; }


	}
}