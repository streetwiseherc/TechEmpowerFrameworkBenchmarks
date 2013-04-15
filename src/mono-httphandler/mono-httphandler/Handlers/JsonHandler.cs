using System;
using System.Web;

namespace monohttphandler
{
	public class JsonHandler : IHttpHandler
	{
		public bool IsReusable
		{
			get { return false; }
		}
		
		public void ProcessRequest(HttpContext context)
		{
			JsonHelpers.WriteJson(new { message = "Hello World!" }, context);
		}
	}
}

