using System;
using System.Web;

namespace monohttphandler
{
	internal static class HttpHelpers
	{
		public static int GetQueryStringInteger(this HttpRequest request, string name, int defaultValue = 0)
		{
			int returnValue = defaultValue;

			string stringValue = request.QueryString[name];

			if (!string.IsNullOrEmpty(stringValue))
			{
				Int32.TryParse(stringValue, out returnValue);
			}

			return returnValue;
		}
	}
}

