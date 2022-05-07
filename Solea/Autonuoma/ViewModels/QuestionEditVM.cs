using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;

namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// Model of 'Modelis' entity used in creation and editing forms.
	/// </summary>
	public class QuestionEditVM
	{
		/// <summary>
		/// Entity data
		/// </summary>
		public class QuestionM
		{
		    [DisplayName("User")]
		    public string fk_User { get; set; }

		    [DisplayName("Question")]
	    	public string Questions { get; set; } // error when write Question, because of same name as class

			[DisplayName("Id")]
		     public int Id { get; set; }

			 [DisplayName("Content")]
		     public string Content { get; set; }

		}

		/// <summary>
		/// Select lists for making drop downs for choosing values of entity fields.
		/// </summary>
		public class ListsM
		{
			public IList<SelectListItem> Users { get; set; }
		}

		/// <summary>
		/// Entity view.
		/// </summary>
		public QuestionM Question { get; set; } = new QuestionM();
		public User user {get; set;}

		/// <summary>
		/// Lists for drop down controls.
		/// </summary>
		public ListsM Lists { get; set; } = new ListsM();
	}
}