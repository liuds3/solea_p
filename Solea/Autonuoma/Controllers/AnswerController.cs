using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers
{
	/// <summary>
	/// Controller for working with 'Modelis' entity.
	/// </summary>
	public class AnswerController : Controller
	{

		/// <summary>
		/// This is invoked when either 'Index' action is requested or no action is provided.
		/// </summary>
		/// <returns>Entity list view.</returns>
		public ActionResult Index()
		{
			var answers = AnswerRepo.List();
			return View(answers);
		}

		/// <summary>
		/// This is invoked when creation form is first opened in browser.
		/// </summary>
		/// <returns>Creation form view.</returns>
		public ActionResult Create(string q, int id)
		{
			//var answerEvm = new AnswerEditVM();
			var answerEvm = new AnswerEditVM();
			PopulateSelections(answerEvm);
			answerEvm.Answer.fk_Questions=q;
			answerEvm.Lists.Questions_Id=id;
			return View(answerEvm);
		}

		/// <summary>
		/// This is invoked when buttons are pressed in the creation form.
		/// </summary>
		/// <param name="answerEvm">Entity model filled with latest data.</param>
		/// <returns>Returns creation from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Create(AnswerEditVM answerEvm, int id)
		{
			//form field validation passed?
			if( ModelState.IsValid )
			{
				AnswerRepo.Insert(answerEvm);

				//save success, go back to the entity list
				return RedirectToAction("Content", "Question", new { id = id});
			}

			//form field validation failed, go back to the form
			PopulateSelections(answerEvm);
			return View(answerEvm);
		}

		/// <summary>
		/// This is invoked when editing form is first opened in browser.
		/// </summary>
		/// <param name="id">ID of the entity to edit.</param>
		/// <returns>Editing form view.</returns>
		public ActionResult Edit(int id,QuestionListVM q)
		{
			var answerEvm = AnswerRepo.Find(id);
			PopulateSelections(answerEvm);

			return View(answerEvm);
		}

		/// <summary>
		/// This is invoked when buttons are pressed in the editing form.
		/// </summary>
		/// <param name="id">ID of the entity being edited</param>
		/// <param name="autoEvm">Entity model filled with latest data.</param>
		/// <returns>Returns editing from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Edit(int id, AnswerEditVM answerEvm, QuestionListVM q)
		{
			//form field validation passed?
			if( ModelState.IsValid )
			{
				AnswerRepo.Update(answerEvm);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}

			//form field validation failed, go back to the form
			PopulateSelections(answerEvm);
			return View(answerEvm);
		}

		/// </summary>
		/// <param name="id">ID of the entity to delete.</param>
		/// <returns>Deletion form view.</returns>
		public ActionResult Delete(int id)
		{
			var questionLvm = AnswerRepo.FindForDeletion(id);
			return View(questionLvm);
		}

		/// <summary>
		/// This is invoked when deletion is confirmed in deletion form
		/// </summary>
		/// <param name="id">ID of the entity to delete.</param>
		/// <returns>Deletion form view on error, redirects to Index on success.</returns>
		[HttpPost]
		public ActionResult DeleteConfirm(int id)
		{
			//try deleting, this will fail if foreign key constraint fails
			try
			{
				AnswerRepo.Delete(id);

				//deletion success, redired to list form
				return RedirectToAction("Index");
			}
			//entity in use, deletion not permitted
			catch( MySql.Data.MySqlClient.MySqlException )
			{
				//enable explanatory message and show delete form
				ViewData["deletionNotPermitted"] = true;

				var questionLvm = AnswerRepo.FindForDeletion(id);

				return View("Delete", questionLvm);
			}
		}

		/// <summary>
		/// Populates select lists used to render drop down controls.
		/// </summary>
		/// <param name="answerEvm">'Automobilis' view model to append to.</param>
		public void PopulateSelections(AnswerEditVM answersEvm)
		{
			//load entities for the select lists
			var users = UserRepo.List();

			//build select lists
			answersEvm.Lists.Users =
				users.Select(it => {
					return
						new SelectListItem() {
							Value = Convert.ToString(it.Name),
							Text = Convert.ToString(it.Name)
						};
				})
				.ToList();
             //load entities for the select lists
			/*var questions = QuestionRepo.List();

			answersEvm.Lists.Questions =
				questions.Select(it => {
					return
						new SelectListItem() {
							Value = Convert.ToString(it.Questions),
							Text = Convert.ToString(it.Questions)
						};
				})
				.ToList();*/
			
		}
	}
}
