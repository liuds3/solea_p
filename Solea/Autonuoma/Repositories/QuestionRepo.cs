using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
	public class QuestionRepo
	{
		public static List<QuestionListVM> List()
		{
			var result = new List<QuestionListVM>();

			var query =
				$@"SELECT
					md.user,
					md.question,
					md.content,
					md.id,
					md.likes,
					md.dislikes
					FROM
					`{Config.TblPrefix}questions` md
					LEFT JOIN `{Config.TblPrefix}users` usr ON md.user=usr.name
				ORDER BY md.id DESC";

			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				result.Add(new QuestionListVM
				{
					fk_User = Convert.ToString(item["user"]),
                    Questions = Convert.ToString(item["question"]),
					Content = Convert.ToString(item["content"]),
				    Id = Convert.ToInt32(item["id"]),
					Likes = Convert.ToInt32(item["likes"]),
					Dislikes = Convert.ToInt32(item["dislikes"])

				});
			}

			return result;
		}

		
		public static QuestionEditVM Find(int id)
		{
			var mevm = new QuestionEditVM();

			var query = $@"SELECT * FROM `{Config.TblPrefix}questions` WHERE id=?id";

			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.String).Value = id;
				});

			foreach( DataRow item in dt )
			{
				mevm.Question.fk_User = Convert.ToString(item["user"]);
				mevm.Question.Questions = Convert.ToString(item["question"]);
				mevm.Question.Content = Convert.ToString(item["content"]);
				mevm.Question.Id = Convert.ToInt32(item["id"]);
				mevm.Question.Likes = Convert.ToInt32(item["likes"]);
				mevm.Question.Dislikes = Convert.ToInt32(item["dislikes"]);
			}

			return mevm;
		}

		public static List<QuestionListVM> FindList(string search)
		{
			var mevm = List();
			if(search!=null){
			string[] words = search.Split(' ');
			List<QuestionListVM> questions = new List<QuestionListVM>();
			foreach(var item in mevm){
				if(words.All(item.Questions.Contains)){
					questions.Add(new QuestionListVM{
						fk_User = item.fk_User,
						Questions = item.Questions,
						Content = item.Content,
						Id = item.Id,
						Likes = item.Likes,
						Dislikes = item.Dislikes
					});
				}	
			}
			return questions;
			}

			return mevm;
		}

		

		public static QuestionListVM FindForDeletion(int id)
		{
			var mlvm = new QuestionListVM();

			var query =
				$@"SELECT
					md.user,
					md.question,
					md.content,
					md.id,
					md.likes,
					md.dislikes
				FROM
					`{Config.TblPrefix}questions` md
					LEFT JOIN `{Config.TblPrefix}users` usr ON md.user=usr.name
				WHERE
					md.id = ?id";
			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.Int32).Value = id;
				});

			foreach( DataRow item in dt )
			{
				mlvm.fk_User = Convert.ToString(item["user"]);
				mlvm.Questions = Convert.ToString(item["question"]);
				mlvm.Content = Convert.ToString(item["content"]);
				mlvm.Id = Convert.ToInt32(item["id"]);
				mlvm.Likes = Convert.ToInt32(item["likes"]);
				mlvm.Dislikes = Convert.ToInt32(item["dislikes"]);
			}

			return mlvm;
		}

		public static void Update(QuestionEditVM QuestionEvm)
		{
			var query =
				$@"UPDATE `{Config.TblPrefix}questions`
				SET
					user=?user,
					question=?question,
					content=?content,
					likes=?likes,
					dislikes=?dislikes
				WHERE
					id=?id";

			Sql.Update(query, args => {
				args.Add("?user", MySqlDbType.VarChar).Value = QuestionEvm.Question.fk_User;
				args.Add("?question", MySqlDbType.VarChar).Value = QuestionEvm.Question.Questions;
				args.Add("?id", MySqlDbType.Int32).Value = QuestionEvm.Question.Id;
				args.Add("?content", MySqlDbType.VarChar).Value = QuestionEvm.Question.Content;
				args.Add("?likes", MySqlDbType.Int32).Value = QuestionEvm.Question.Id;
				args.Add("?dislikes", MySqlDbType.Int32).Value = QuestionEvm.Question.Id;
			});
		}

		public static void Insert(QuestionEditVM QuestionEvm)
		{
			var query =
				$@"INSERT INTO `{Config.TblPrefix}questions`
				(
					user,
					question,
					content,
					id,
					likes,
					dislikes
				)
				VALUES(
					?user,
					?question,
					?content,
					?id,
					?likes,
					?dislikes
				)";

			Sql.Insert(query, args => {
				args.Add("?user", MySqlDbType.VarChar).Value = QuestionEvm.Question.fk_User;
				args.Add("?question", MySqlDbType.VarChar).Value = QuestionEvm.Question.Questions;
				args.Add("?content", MySqlDbType.VarChar).Value = QuestionEvm.Question.Content;
				args.Add("?id", MySqlDbType.Int32).Value = QuestionEvm.Question.Id;
				args.Add("?likes", MySqlDbType.Int32).Value = QuestionEvm.Question.Likes;
				args.Add("?dislikes", MySqlDbType.Int32).Value = QuestionEvm.Question.Dislikes;
			});
		}

		public static void Delete(int id)
		{
			var query = $@"DELETE FROM `{Config.TblPrefix}questions` WHERE id=?id";
			Sql.Delete(query, args => {
				args.Add("?id", MySqlDbType.Int32).Value = id;
			});
		}
	}
}