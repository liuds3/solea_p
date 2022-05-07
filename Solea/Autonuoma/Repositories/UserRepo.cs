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
				User.Currency = Convert.ToInt32(item["currency"]);
				User.Email = Convert.ToString(item["email"]);
				User.Password = Convert.ToString(item["password"]);
			}

			return User;
		}

		public static User Find(User user)
		{
			var User = new User();

			var query = $@"SELECT * FROM `{Config.TblPrefix}users` WHERE name=?name AND password=?password";
			var dt = 
				Sql.Query(query, args => {
					args.Add("?password", MySqlDbType.VarChar).Value = user.Password;
					args.Add("?name", MySqlDbType.VarChar).Value = user.Name;
				});

			foreach( DataRow item in dt )
			{
				User.Id = Convert.ToInt32(item["id"]);
				User.Name = Convert.ToString(item["name"]);
				User.Currency = Convert.ToInt32(item["currency"]);
				User.Email = Convert.ToString(item["email"]);
				User.Password = Convert.ToString(item["password"]);
			}

			return User;
		}

		public static void Update(User User)
		{			
			var query = 
				$@"UPDATE `{Config.TblPrefix}users` 
				SET 
					name=?name,
					currency=?currency,
					email=?email,
					password=?password
				WHERE 
					id=?id";

			Sql.Update(query, args => {
				args.Add("?name", MySqlDbType.VarChar).Value = User.Name;
				args.Add("?id", MySqlDbType.VarChar).Value = User.Id;
				args.Add("?currency", MySqlDbType.VarChar).Value = User.Currency;
				args.Add("?email", MySqlDbType.VarChar).Value = User.Email;
				args.Add("?password", MySqlDbType.VarChar).Value = User.Password;
			});							
		}

		public static void Insert(User User)
		{			
				var query =
				$@"INSERT INTO `{Config.TblPrefix}users`
				(
					id,
                    name,
					currency,
					email,
					password
				)
				VALUES(
					?id,
					?name,
					?currency,
					?email,
					?password
				)";

			Sql.Insert(query, args => {
				args.Add("?id", MySqlDbType.VarChar).Value = User.Id;
				args.Add("?name", MySqlDbType.VarChar).Value = User.Name;
				args.Add("?currency", MySqlDbType.VarChar).Value = User.Currency;
				args.Add("?email", MySqlDbType.VarChar).Value = User.Email;
				args.Add("?password", MySqlDbType.VarChar).Value = User.Password;
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