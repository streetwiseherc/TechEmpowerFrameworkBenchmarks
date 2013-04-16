using Nancy;
using System;

namespace mononancydapper
{
	public class HelloModule : NancyModule
	{
		public HelloModule ()
		{
			Get["/json"] = parameters => {
				return Response.AsJson(new { message = "Hello World!" });
			};
		}
	}
}

