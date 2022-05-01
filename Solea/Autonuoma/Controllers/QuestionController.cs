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
	public class QuestionController : Controller
	{

		/// <summary>
		/// This is invoked when either 'Index' action is requested or no action is provided.
		/// </summary>
		/// <returns>Entity list view.</returns>
		public ActionResult Index()
		{
			var questions = QuestionRepo.List();
			return View(questions);
		}
		
		public ActionResult Content(int id)
		{
			var answerss = AnswerRepo.QuestionAnswers(id);
			var questions = QuestionRepo.FindForDeletion(id);
			var vModel = new Answers();
			vModel.answers=answerss;
			vModel.question=questions;
			return View(vModel);
		}
		/// <summary>
		/// This is invoked when creation form is first opened in browser.
		/// </summary>
		/// <returns>Creation form view.</returns>
		public ActionResult Create()
		{
			var questionEvm = new QuestionEditVM();
			PopulateSelections(questionEvm);
			return View(questionEvm);
		}

		/// <summary>
		/// This is invoked when buttons are pressed in the creation form.
		/// </summary>
		/// <param name="questionEvm">Entity model filled with latest data.</param>
		/// <returns>Returns creation from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Create(QuestionEditVM questionEvm)
		{
			//form field validation passed?
			if( ModelState.IsValid )
			{
				QuestionRepo.Insert(questionEvm);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}

			//form field validation failed, go back to the form
			PopulateSelections(questionEvm);
			return View(questionEvm);
		}

		/// <summary>
		/// This is invoked when editing form is first opened in browser.
		/// </summary>
		/// <param name="id">ID of the entity to edit.</param>
		/// <returns>Editing form view.</returns>
		public ActionResult Edit(int id)
		{
			var questionEvm = QuestionRepo.Find(id);
			PopulateSelections(questionEvm);

			return View(questionEvm);
		}

		/// <summary>
		/// This is invoked when buttons are pressed in the editing form.
		/// </summary>
		/// <param name="id">ID of the entity being edited</param>
		/// <param name="autoEvm">Entity model filled with latest data.</param>
		/// <returns>Returns editing from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Edit(int id, QuestionEditVM questionEvm)
		{
			//form field validation passed?
			if( ModelState.IsValid )
			{
				QuestionRepo.Update(questionEvm);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}

			//form field validation failed, go back to the form
			PopulateSelections(questionEvm);
			return View(questionEvm);
		}

		/// </summary>
		/// <param name="id">ID of the entity to delete.</param>
		/// <returns>Deletion form view.</returns>
		public ActionResult Delete(int id)
		{
			var questionLvm = QuestionRepo.FindForDeletion(id);
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
				QuestionRepo.Delete(id);

				//deletion success, redired to list form
				return RedirectToAction("Index");
			}
			//entity in use, deletion not permitted
			catch( MySql.Data.MySqlClient.MySqlException )
			{
				//enable explanatory message and show delete form
				ViewData["deletionNotPermitted"] = true;

				var questionLvm = QuestionRepo.FindForDeletion(id);

				return View("Delete", questionLvm);
			}
		}

		/// <summary>
		/// Populates select lists used to render drop down controls.
		/// </summary>
		/// <param name="questionEvm">'Automobilis' view model to append to.</param>
		public void PopulateSelections(QuestionEditVM questionsEvm)
		{
			//load entities for the select lists
			var users = UserRepo.List();

			//build select lists
			questionsEvm.Lists.Users =
				users.Select(it => {
					return
						new SelectListItem() {
							Value = Convert.ToString(it.Name),
							Text = Convert.ToString(it.Name)
						};
				})
				.ToList();
		}
	}
}
