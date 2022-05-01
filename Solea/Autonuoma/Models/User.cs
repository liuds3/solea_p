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
	}
}