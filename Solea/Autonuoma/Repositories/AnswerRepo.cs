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
	public class AnswerRepo
	{
		public static List<AnswerListVM> List()
		{
			var result = new List<AnswerListVM>();

			var query =
				$@"SELECT
					md.user,
					md.question,
					md.answer,
					md.id,
					md.likes,
					md.dislikes,
					md.best
					FROM
					`{Config.TblPrefix}answers` md
					LEFT JOIN `{Config.TblPrefix}users` usr ON md.user=usr.name
					LEFT JOIN `{Config.TblPrefix}questions` que ON md.question=que.question
				ORDER BY md.id DESC";

			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				result.Add(new AnswerListVM
				{
					fk_User = Convert.ToString(item["user"]),
                    fk_Questions = Convert.ToString(item["question"]),
					Answers = Convert.ToString(item["answer"]),
				    Id = Convert.ToInt32(item["id"]),
					Likes = Convert.ToInt32(item["likes"]),
					Dislikes = Convert.ToInt32(item["dislikes"]),
					best = Convert.ToInt32(item["best"])
				});
			}

			return result;
		}
		public static List<AnswerListVM> QuestionAnswers(int id)
		{
			var result = new List<AnswerListVM>();

			var query =
				$@"SELECT
					md.user,
					md.question,
					md.answer,
					md.id,
					md.likes,
					md.dislikes,
					md.best
					FROM
					`{Config.TblPrefix}answers` md
					LEFT JOIN `{Config.TblPrefix}users` usr ON md.user=usr.name
					LEFT JOIN `{Config.TblPrefix}questions` que ON md.question=que.question
				WHERE
					que.id = ?id";

			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.Int32).Value = id;
				});


			foreach( DataRow item in dt )
			{
				result.Add(new AnswerListVM
				{
					fk_User = Convert.ToString(item["user"]),
                    fk_Questions = Convert.ToString(item["question"]),
					Answers = Convert.ToString(item["answer"]),
				    Id = Convert.ToInt32(item["id"]),
					Likes = Convert.ToInt32(item["likes"]),
					Dislikes = Convert.ToInt32(item["dislikes"]),
					best = Convert.ToInt32(item["best"])

				});
			}

			return result;
		}
		/*public static QuestionEditVM FindQuestion(int id)
		{
			var mevm = new QuestionEditVM();

			var query = $@"SELECT * FROM `{Config.TblPrefix}questions` WHERE id=?id";

			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.String).Value = id;
				});

			foreach( DataRow item in dt )
			{
				mevm.Question.Questions = Convert.ToString(item["question"]);
			}

			return mevm;
		}*/

		public static AnswerEditVM Find(int id)
		{
			var mevm = new AnswerEditVM();

			var query = $@"SELECT * FROM `{Config.TblPrefix}answers` WHERE id=?id";

			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.String).Value = id;
				});

			foreach( DataRow item in dt )
			{
				mevm.Answer.fk_User = Convert.ToString(item["user"]);
				mevm.Answer.fk_Questions = Convert.ToString(item["question"]);
				mevm.Answer.Answers = Convert.ToString(item["answer"]);
				mevm.Answer.Id = Convert.ToInt32(item["id"]);
				mevm.Answer.Likes = Convert.ToInt32(item["likes"]);
				mevm.Answer.Dislikes = Convert.ToInt32(item["dislikes"]);
				mevm.Answer.best = Convert.ToInt32(item["best"]);
			}

			return mevm;
		}

		public static AnswerListVM FindForDeletion(int id)
		{
			var mlvm = new AnswerListVM();

			var query =
				$@"SELECT
					md.user,
					md.question,
					md.answer,
					md.id,
					md.likes,
					md.dislikes,
					md.best
				FROM
					`{Config.TblPrefix}answers` md
					LEFT JOIN `{Config.TblPrefix}users` usr ON md.user=usr.name
					LEFT JOIN `{Config.TblPrefix}questions` que ON md.question=que.question
				WHERE
					md.id = ?id";
			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.Int32).Value = id;
				});

			foreach( DataRow item in dt )
			{
				mlvm.fk_User = Convert.ToString(item["user"]);
				mlvm.fk_Questions = Convert.ToString(item["question"]);
				mlvm.Answers = Convert.ToString(item["answer"]);
				mlvm.Id = Convert.ToInt32(item["id"]);
				mlvm.Likes = Convert.ToInt32(item["likes"]);
				mlvm.Dislikes = Convert.ToInt32(item["dislikes"]);
				mlvm.best = Convert.ToInt32(item["best"]);
			}

			return mlvm;
		}

		public static void Update(AnswerEditVM AnswerEvm)
		{
			var query =
				$@"UPDATE `{Config.TblPrefix}answers`
				SET
					user=?user,
					question=?question,
					answer=?answer,
					likes=?likes,
					dislikes=?dislikes,
					best=?best
				WHERE
					id=?id";

			Sql.Update(query, args => {
				args.Add("?user", MySqlDbType.VarChar).Value = AnswerEvm.Answer.fk_User;
				args.Add("?question", MySqlDbType.VarChar).Value = AnswerEvm.Answer.fk_Questions;
				args.Add("?answer", MySqlDbType.VarChar).Value = AnswerEvm.Answer.Answers;
				args.Add("?id", MySqlDbType.Int32).Value = AnswerEvm.Answer.Id;
				args.Add("?likes", MySqlDbType.Int32).Value = AnswerEvm.Answer.Likes;
				args.Add("?dislikes", MySqlDbType.Int32).Value = AnswerEvm.Answer.Dislikes;
				args.Add("?best", MySqlDbType.Int32).Value = AnswerEvm.Answer.best;
			});
		}

		public static void Insert(AnswerEditVM AnswerEvm)
		{
			var query =
				$@"INSERT INTO `{Config.TblPrefix}answers`
				(
					user,
					question,
					answer,
					id,
					likes,
					dislikes,
					best
				)
				VALUES(
					?user,
					?question,
					?answer,
					?id,
					?likes,
					?dislikes,
					?best
				)";

			Sql.Insert(query, args => {
				args.Add("?user", MySqlDbType.VarChar).Value = AnswerEvm.Answer.fk_User;
				args.Add("?question", MySqlDbType.VarChar).Value = AnswerEvm.Answer.fk_Questions;
				args.Add("?answer", MySqlDbType.VarChar).Value = AnswerEvm.Answer.Answers;
				args.Add("?id", MySqlDbType.Int32).Value = AnswerEvm.Answer.Id;
				args.Add("?likes", MySqlDbType.Int32).Value = AnswerEvm.Answer.Likes;
				args.Add("?dislikes", MySqlDbType.Int32).Value = AnswerEvm.Answer.Dislikes;
				args.Add("?best", MySqlDbType.Int32).Value = AnswerEvm.Answer.best;
			});
		}

		public static void Delete(int id)
		{
			var query = $@"DELETE FROM `{Config.TblPrefix}answers` WHERE id=?id";
			Sql.Delete(query, args => {
				args.Add("?id", MySqlDbType.Int32).Value = id;
			});
		}
	}
}