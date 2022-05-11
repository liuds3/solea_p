using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
	public class LikedRepo
	{
		public static List<Liked> List()
		{
			var Likeds = new List<Liked>();

			string query = $@"SELECT * FROM `{Config.TblPrefix}liked` ORDER BY id ASC";
			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				Likeds.Add(new Liked
				{
					QuestionId = Convert.ToInt32(item["QuestionId"]),
					AnswerId = Convert.ToInt32(item["AnswerId"]),
					UserId = Convert.ToInt32(item["UserId"]),
					Id = Convert.ToInt32(item["id"]),
					likedOrDisliked = Convert.ToInt32(item["likedOrDisliked"])
				});
			}

			return Likeds;
		}
		//This is used to find a Liked based on the id
		public static Liked Find(int id, int idUser)
		{
			var Liked = new Liked();

			var query = $@"SELECT * FROM `{Config.TblPrefix}liked` WHERE QuestionId=?QuestionId AND UserId=?UserId";
			var dt = 
				Sql.Query(query, args => {
					args.Add("?QuestionId", MySqlDbType.Int32).Value = id;
					args.Add("?UserId", MySqlDbType.Int32).Value = idUser;
				});

			foreach( DataRow item in dt )
			{
				Liked.QuestionId = Convert.ToInt32(item["QuestionId"]);
				Liked.AnswerId = Convert.ToInt32(item["AnswerId"]);
				Liked.UserId = Convert.ToInt32(item["UserId"]);
				Liked.Id = Convert.ToInt32(item["id"]);
				Liked.likedOrDisliked = Convert.ToInt32(item["likedOrDisliked"]);
			}

			return Liked;
		}

		public static Liked Find(int id, int idUser, int n)
		{
			var Liked = new Liked();

			var query = $@"SELECT * FROM `{Config.TblPrefix}liked` WHERE AnswerId=?AnswerId AND UserId=?UserId";
			var dt = 
				Sql.Query(query, args => {
					args.Add("?AnswerId", MySqlDbType.Int32).Value = id;
					args.Add("?UserId", MySqlDbType.Int32).Value = idUser;
				});

			foreach( DataRow item in dt )
			{
				Liked.QuestionId = Convert.ToInt32(item["QuestionId"]);
				Liked.AnswerId = Convert.ToInt32(item["AnswerId"]);
				Liked.UserId = Convert.ToInt32(item["UserId"]);
				Liked.Id = Convert.ToInt32(item["id"]);
				Liked.likedOrDisliked = Convert.ToInt32(item["likedOrDisliked"]);
			}

			return Liked;
		}
		//This is used to check when loggin in whether a Liked inputed a correct name and password
		

		public static void Update(int QuestionId, int AnswerId, int UserId, int Id, int likedOrDisliked)
		{			
			var query = 
				$@"UPDATE `{Config.TblPrefix}liked` 
				SET 
					QuestionId=?QuestionId,
					AnswerId=?AnswerId,
					UserId=?UserId,
					likedOrDisliked=?likedOrDisliked
				WHERE 
					id=?id";

			Sql.Update(query, args => {
				args.Add("?QuestionId", MySqlDbType.Int32).Value = QuestionId;
				args.Add("?AnswerId", MySqlDbType.Int32).Value = AnswerId;
				args.Add("?UserId", MySqlDbType.Int32).Value = UserId;
				args.Add("?id", MySqlDbType.Int32).Value = Id;
				args.Add("?likedOrDisliked", MySqlDbType.Int32).Value = likedOrDisliked;
			});							
		}

		public static void Insert(int QuestionId, int AnswerId, int UserId, int Id, int likedOrDisliked)
		{			
				var query =
				$@"INSERT INTO `{Config.TblPrefix}liked`
				(
					QuestionId,
					AnswerId,
                    UserId,
					id,
					likedOrDisliked
				)
				VALUES(
					?QuestionId,
					?AnswerId,
					?UserId,
					?id,
					?likedOrDisliked
				)";

			Sql.Insert(query, args => {
				args.Add("?QuestionId", MySqlDbType.Int32).Value = QuestionId;
				args.Add("?AnswerId", MySqlDbType.Int32).Value = AnswerId;
				args.Add("?UserId", MySqlDbType.Int32).Value = UserId;
				args.Add("?id", MySqlDbType.Int32).Value = Id;
				args.Add("?likedOrDisliked", MySqlDbType.Int32).Value = likedOrDisliked;
			});
		}

		public static void Delete(int id)
		{			
			var query = $@"DELETE FROM `{Config.TblPrefix}liked` where id=?id";
			Sql.Delete(query, args => {
				args.Add("?id", MySqlDbType.Int32).Value = id;
			});			
		}
	}
}