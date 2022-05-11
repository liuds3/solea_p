using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// Model of 'Modelis' entity used in creation and editing forms.
	/// </summary>
	public class AnswerEditVM
	{
		/// <summary>
		/// Entity data
		/// </summary>
		public class AnswerM
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

		/// <summary>
		/// Select lists for making drop downs for choosing values of entity fields.
		/// </summary>
		public class ListsM
		{
			public IList<SelectListItem> Users { get; set; }

            public string Questions { get; set; }

			public int Questions_Id { get; set; }

		}

		/// <summary>
		/// Entity view.
		/// </summary>
		public AnswerM Answer { get; set; } = new AnswerM();

		public User user {get; set;}
		/// <summary>
		/// Lists for drop down controls.
		/// </summary>
		public ListsM Lists { get; set; } = new ListsM();
	}
}