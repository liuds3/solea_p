using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
	/// <summary>
	/// Model of 'Modelis' entity.
	/// </summary>
	public class Question
	{
		[DisplayName("User")]
		public string fk_User { get; set; }

		[DisplayName("Question")]
		public string Questions { get; set; } // error when write Question, because of same name as class

		[DisplayName("Id")]
		public int Id { get; set; }

		[DisplayName("Content")]
		public string Content { get; set; }

		[DisplayName("Likes")]
		public int Likes { get; set; }

		[DisplayName("Dislikes")]
		public int Dislikes { get; set; }

		[DisplayName("topAnswer")]
		public int topAnswer { get; set; }
	}
}