using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
	/// <summary>
	/// Model of 'Modelis' entity.
	/// </summary>
	public class Liked
	{
		[DisplayName("QuestionId")]
		public int QuestionId { get; set; }

		[DisplayName("AnswerId")]
		public int AnswerId { get; set; }

		[DisplayName("UserId")]
		public int UserId { get; set; }

		[DisplayName("Id")]
		public int Id { get; set; }

		[DisplayName("LikedOrDisliked")]
		public int likedOrDisliked { get; set; }
	}
}