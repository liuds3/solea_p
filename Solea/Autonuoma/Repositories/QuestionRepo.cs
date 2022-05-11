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
					md.id
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
				    Id = Convert.ToInt32(item["id"])

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
						Id = item.Id
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
					md.id
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
					content=?content
				WHERE
					id=?id";

			Sql.Update(query, args => {
				args.Add("?user", MySqlDbType.VarChar).Value = QuestionEvm.Question.fk_User;
				args.Add("?question", MySqlDbType.VarChar).Value = QuestionEvm.Question.Questions;
				args.Add("?id", MySqlDbType.Int32).Value = QuestionEvm.Question.Id;
				args.Add("?content", MySqlDbType.VarChar).Value = QuestionEvm.Question.Content;
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
					id
				)
				VALUES(
					?user,
					?question,
					?content,
					?id
				)";

			Sql.Insert(query, args => {
				args.Add("?user", MySqlDbType.VarChar).Value = QuestionEvm.Question.fk_User;
				args.Add("?question", MySqlDbType.VarChar).Value = QuestionEvm.Question.Questions;
				args.Add("?content", MySqlDbType.VarChar).Value = QuestionEvm.Question.Content;
				args.Add("?id", MySqlDbType.Int32).Value = QuestionEvm.Question.Id;
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