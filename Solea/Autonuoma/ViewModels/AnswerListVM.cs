using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// Model of 'Modelis' entity used in lists.
	/// </summary>
	public class AnswerListVM
	{
		    [DisplayName("User")]
		    public string fk_User { get; set; }

	    	[DisplayName("Question")]
	    	public string fk_Questions { get; set; } 

            [DisplayName("Answer")]
		    public string Answers { get; set; } 
			
			[DisplayName("Id")]
	     	public int Id { get; set; }

			[DisplayName("Likes")]
			public int Likes { get; set; }

			[DisplayName("Dislikes")]
			public int Dislikes { get; set; }

	}
}