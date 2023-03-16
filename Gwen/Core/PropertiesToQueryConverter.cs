using System.Reflection;

namespace Gwen.Core
{
	internal static class PropertiesToQueryConverter
	{
		public static string ToQuery<T>(T typeValue)
		{
			string query = "";
			PropertyInfo[] properties = typeof(T).GetProperties();
			foreach (PropertyInfo propertyInfo in properties)
			{
				var value = propertyInfo.GetValue(typeValue, null);
				if (value == null)
					continue;
				char queryPreprend = string.IsNullOrEmpty(query) ? '?' : '&';
				query += $"{queryPreprend}{propertyInfo.Name.ToLower()}={value}";
			}
			return query;
		}

		public static T ToType<T>(string query)
		{
			throw new NotImplementedException();
		}
	}
}
