using System;
using System.Collections;
using MySql.Data.MySqlClient;

namespace Jf.MySql.Data.Collations
{
	// ReSharper disable once InconsistentNaming
	public static class Utf8mb3
	{
		public static void Enable()
		{
			// Add internal mapping of database utf8mb3 charset to .NET framework's UTF-8 encoding
			var mappingField = System.Reflection.Assembly.GetAssembly(typeof(MySqlConnection))
				.GetType("MySql.Data.MySqlClient.CharSetMap").GetField("mapping",
					System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField |
					System.Reflection.BindingFlags.Static);

			if (mappingField != null)
			{
				var mappingDictionary = (IDictionary)mappingField.GetValue(null);
				var utf8Mapping = mappingDictionary["utf8"];

				if (utf8Mapping != null)
				{
					try
					{
						mappingDictionary.Add("utf8mb3", utf8Mapping);
					}
					catch (ArgumentException)
					{
						// Item already exist
					}
				}
			}
		}
	}
}