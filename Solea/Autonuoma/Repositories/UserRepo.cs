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
	public class UserRepo
	{
		public static List<User> List()
		{
			var users = new List<User>();

			string query = $@"SELECT * FROM `{Config.TblPrefix}users` ORDER BY id ASC";
			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				users.Add(new User
				{
					Id = Convert.ToInt32(item["id"]),
					Name = Convert.ToString(item["name"]),
					Currency = Convert.ToInt32(item["currency"]),
					Email = Convert.ToString(item["email"]),
					Password = Convert.ToString(item["password"]),
				});
			}

			return users;
		}

		public static User Find(int id)
		{
			var User = new User();

			var query = $@"SELECT * FROM `{Config.TblPrefix}users` WHERE id=?id";
			var dt = 
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.Int32).Value = id;
				});

			foreach( DataRow item in dt )
			{
				User.Id = Convert.ToInt32(item["id"]);
				User.Name = Convert.ToString(item["name"]);
			}

			return User;
		}

		public static void Update(User User)
		{			
			var query = 
				$@"UPDATE `{Config.TblPrefix}users` 
				SET 
					name=?name 
				WHERE 
					id=?id";

			Sql.Update(query, args => {
				args.Add("?name", MySqlDbType.VarChar).Value = User.Name;
				args.Add("?id", MySqlDbType.VarChar).Value = User.Id;
			});							
		}

		public static void Insert(User User)
		{			
				var query =
				$@"INSERT INTO `{Config.TblPrefix}users`
				(
					id,
                    name
				)
				VALUES(
					?id,
					?name
				)";

			Sql.Insert(query, args => {
				args.Add("?id", MySqlDbType.VarChar).Value = User.Id;
				args.Add("?name", MySqlDbType.VarChar).Value = User.Name;
			});
		}

		public static void Delete(int id)
		{			
			var query = $@"DELETE FROM `{Config.TblPrefix}users` where id=?id";
			Sql.Delete(query, args => {
				args.Add("?id", MySqlDbType.Int32).Value = id;
			});			
		}
	}
}