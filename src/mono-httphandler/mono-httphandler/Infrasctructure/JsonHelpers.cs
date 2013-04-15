using System;
using System.Configuration;
using System.IO;
using System.Web;

namespace monohttphandler
{
	internal enum JsonLibrary
	{
		WebScript = 0,
		Newtonsoft = 1,
		ServiceStack = 2
	}

	internal class JsonHelpers
	{
		public static void WriteJson(object obj, HttpContext context)
		{
			context.Response.ContentType = "application/json";
			JsonLibrary jsonLibrary = (JsonLibrary) context.Request.GetQueryStringInteger("json-lib");
			JsonHelpers.WriteJson(obj, context.Response.Output, jsonLibrary);
		}

		public static void WriteJson(object obj, TextWriter writer, JsonLibrary jsonLibrary = JsonLibrary.WebScript) 
		{
			switch (jsonLibrary)
			{
				case JsonLibrary.Newtonsoft:
					WriteJsonUsingNewtonsoftSerializer(obj, writer);
					break;

				case JsonLibrary.ServiceStack:
					WriteJsonUsingServiceStackSerializer(obj, writer);
					break;

				default:
					WriteJsonUsingWebScriptSerializer(obj, writer);
					break;
			}
		}

		public static void WriteJsonUsingNewtonsoftSerializer(object obj, TextWriter writer)
		{
			Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
			serializer.Serialize(writer, obj);
		}

		public static void WriteJsonUsingServiceStackSerializer(object obj, TextWriter writer)
		{
			ServiceStack.Text.JsonSerializer.SerializeToWriter(obj, writer);
		}

		public static void WriteJsonUsingWebScriptSerializer(object obj, TextWriter writer)
		{
			System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
			writer.Write(serializer.Serialize(obj));
		}
	}
}

