using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
	/// <summary>
	/// Model for 'Marke' entity.
	/// </summary>
	public class User
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