using System.Data;
using MySql.Data.MySqlClient;

namespace Org.Ktu.Isk.P175B602.Autonuoma
{
	/// <summary>
    /// <para>Helper for executing MySQL queries and statements.</para>
    /// <para>Static members are thread safe, instance members are not.</para>
    /// </summary>
	class Sql
	{
		/// <summary>
        /// Execute SELECT query.
        /// </summary>
        /// <param name="query">Query to execute.</param>
        /// <param name="args">Argument binder.</param>
        /// <returns>Rows of the result.</returns>
		public static DataRowCollection Query(string query, Action<MySqlParameterCollection> args = null)
		{
			var dbConnStr = Config.DBConnStr;

			using( var dbCon = new MySqlConnection(dbConnStr) )
			using( var dbCmd = new MySqlCommand(query, dbCon) )
			{
				if( args != null )
					args(dbCmd.Parameters);

				dbCon.Open();
				var da = new MySqlDataAdapter(dbCmd);
				var dt = new DataTable();
				da.Fill(dt);

				return dt.Rows;
			}            
		}

		/// <summary>
        /// Execute INSERT statement.
        /// </summary>
        /// <param name="statement">Statement to execute.</param>
        /// <param name="args">Argument binder.</param>
        /// <returns>Autoincrementable ID of the last record created, if any.</returns>
		public static long Insert(string statement, Action<MySqlParameterCollection> args = null)
		{
			var dbConnStr = Config.DBConnStr;

			using( var dbCon = new MySqlConnection(dbConnStr) )
			using( var dbCmd = new MySqlCommand(statement, dbCon) )
			{
				if( args != null)
					args(dbCmd.Parameters);

				dbCon.Open();
				var numRowsAffected = dbCmd.ExecuteNonQuery();

				return dbCmd.LastInsertedId;
			}            
		}

		/// <summary>
        /// Execute UPDATE statement.
        /// </summary>
        /// <param name="statement">Statement to execute.</param>
        /// <param name="args">Argument binder.</param>
        /// <returns>Number of rows affected.</returns>
		public static int Update(string statement, Action<MySqlParameterCollection> args = null)
		{
			var dbConnStr = Config.DBConnStr;

			using( var dbCon = new MySqlConnection(dbConnStr) )
			using( var dbCmd = new MySqlCommand(statement, dbCon) )
			{
				if( args != null )
					args(dbCmd.Parameters);

				dbCon.Open();
				var numRowsAffected = dbCmd.ExecuteNonQuery();

				return numRowsAffected;
			}            
		}

		/// <summary>
        /// Execute DELETE statement.
        /// </summary>
        /// <param name="statement">Statement to execute.</param>
        /// <param name="args">Argument binder.</param>
        /// <returns>Number of rows affected.</returns>
		public static int Delete(string statement, Action<MySqlParameterCollection> args = null)
		{
			var dbConnStr = Config.DBConnStr;

			using( var dbCon = new MySqlConnection(dbConnStr) )
			using( var dbCmd = new MySqlCommand(statement, dbCon) )
			{
				if( args != null )
					args(dbCmd.Parameters);

				dbCon.Open();
				var numRowsAffected = dbCmd.ExecuteNonQuery();

				return numRowsAffected;
			}            
		}

		/// <summary>
		/// Helper for converting nullable DataRow entries to expected type. Will return default
		/// value for the expected type if entry == DBNull.Value or apply given converter otherwise.
		/// </summary>
		/// <param name="entry">Entry to convert.</param>
		/// <param name="converter">Converter to apply.</param>
		/// <typeparam name="T">Expected type of result.</typeparam>
		/// <returns>default(T) if entry == DBNull.Value, result of converter(entry) otherwise.</returns>
		public static T AllowNull<T>(object entry, Func<object, T> converter)
		{
			if( entry == DBNull.Value )
				return default(T);

			return converter(entry);
		}
	}
}