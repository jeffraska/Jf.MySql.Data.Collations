using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Jf.MySql.Data.Collations
{
	/// <summary>
	/// Filters out collations with NULL id (e.g. UCA-14.0.0) from SHOW COLLATION command
	/// </summary>
	public sealed class Interceptor : BaseCommandInterceptor
	{
		/*
		 * Add following to connectionstring to enable interceptor
		 * ;commandinterceptors=Zoner.Insight.Utilities.Utilities.MySqlCollationInterceptor,Zoner Insight Services
		 */

		public override bool ExecuteReader(string sql, CommandBehavior behavior, ref MySqlDataReader returnValue)
		{
			if (!sql.Equals("SHOW COLLATION", StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}

			using var command = ActiveConnection.CreateCommand();
			
			command.CommandText = "SHOW COLLATION WHERE id IS NOT NULL";
			returnValue = command.ExecuteReader(behavior);

			return true;
		}
	}
}