using Microsoft.AspNetCore.Mvc;
using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;
using System.Diagnostics;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers
{
	/// <summary>
	/// Controller for working with 'Marke' entity.
	/// </summary>
	public class UserController : Controller
	{
		/// <summary>
		/// This is invoked when either 'Index' action is requested or no action is provided.
		/// </summary>
		/// <returns>Entity list view.</returns>
		public ActionResult Index()
		{
			var users = UserRepo.List();
			return View(users);
		}

		/*public ActionResult Login(string name, string password)
		{
			var match = UserRepo.Find(darb.ID);
			return View(users);
		}*/
		//This page is invoked when login button is pressed
		public ActionResult Login()
		{
			return View();
		}

		//This function is invoked when a login form is submited (pressed login) on login page
		//It checks whether a user name and password is found in the data base
		//If found sends user's id to main page, so from there it can be used
		[HttpPost]
		public ActionResult Login1(User user)
		{
			return View(user);
		}
		[HttpPost]
		public ActionResult Login(User user)
		{
			var match = UserRepo.Find(user);
			if( match.Name != user.Name || match.Password != user.Password )
				ModelState.AddModelError("password", "Incorrect name or password");
			if(match.Name == user.Name && match.Password == user.Password && user.Name!=null && user.Password !=null){
				TempData["id"]=match.Id;

				//Loggedin.Login();
				return RedirectToAction("Index", "Question");
				//return View( "Index", nameof(Index));
			}
			return View(user);
		}



		/// <summary>
		/// This is invoked when creation form is first opened in browser.
		/// </summary>
		/// <returns>Creation form view.</returns>
		public ActionResult Create()
		{
			var user = new User();
			return View(user);
		}

		/// <summary>
		/// This is invoked when buttons are pressed in the creation form.
		/// </summary>
		/// <param name="user">Entity model filled with latest data.</param>
		/// <returns>Returns creation from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Create(User user)
		{
			var matchName = UserRepo.Find(user.Name, 1);
			var matchEmail = UserRepo.Find(user.Email);
			if(matchName.Name == "testasAI"){
					Debug.WriteLine("gerai");
				}
			else
				Debug.WriteLine("blogai");

			if( matchName.Name == user.Name)
				ModelState.AddModelError("name", "This name is already taken");
			else if( user.Name==null || user.Name.Length < 5)
				ModelState.AddModelError("name", "Name must be atleast 5 characters long");
			if( matchEmail.Email == user.Email)
				ModelState.AddModelError("email", "This email is already taken");
			else if( user.Email == null || user.Email.Length < 5)
				ModelState.AddModelError("email", "Email must be atleast 5 characters long");
			if(user.Password == null || user.Password.Length < 5)
				ModelState.AddModelError("password", "Password must be atleast 5 characters long");
			//form field validation passed?
			if (ModelState.IsValid && matchName.Name != user.Name && matchEmail.Email != user.Email)
			{
				UserRepo.Insert(user);
				TempData["id"]=UserRepo.Find(user.Name, 1).Id;
				matchName = UserRepo.Find(user.Name, 1);
				/*if(match.Name == "lab"){
					Debug.WriteLine("gerai");
				}
				else
					Debug.WriteLine("blogai");*/
				//save success, go back to the entity list
				return RedirectToAction("Index","Question");
			}

			//form field validation failed, go back to the form
			return View(user);
		}

		/// <summary>
		/// This is invoked when editing form is first opened in browser.
		/// </summary>
		/// <param name="id">ID of the entity to edit.</param>
		/// <returns>Editing form view.</returns>
		/*public ActionResult Edit(int id)
		{
			var user = UserRepo.Find(id);
			return View(user);
		}

		/// <summary>
		/// This is invoked when buttons are pressed in the editing form.
		/// </summary>
		/// <param name="id">ID of the entity being edited</param>		
		/// <param name="marke">Entity model filled with latest data.</param>
		/// <returns>Returns editing from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Edit(int id, User user)
		{
			//form field validation passed?
			if (ModelState.IsValid)
			{
				UserRepo.Update(user);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}

			//form field validation failed, go back to the form
			return View(user);
		}

		/// </summary>
		/// <param name="id">ID of the entity to delete.</param>
		/// <returns>Deletion form view.</returns>
		public ActionResult Delete(int id)
		{
			var user = UserRepo.Find(id);
			return View(user);
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
				UserRepo.Delete(id);

				//deletion success, redired to list form
				return RedirectToAction("Index");
			}
			//entity in use, deletion not permitted
			catch( MySql.Data.MySqlClient.MySqlException )
			{
				//enable explanatory message and show delete form
				ViewData["deletionNotPermitted"] = true;

				var user = UserRepo.Find(id);
				return View("Delete", user);
			}
		}*/
	}
}
