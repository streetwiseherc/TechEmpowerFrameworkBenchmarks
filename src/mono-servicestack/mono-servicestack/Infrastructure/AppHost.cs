using ServiceStack.OrmLite;
using ServiceStack.WebHost.Endpoints;
using System;
using System.Configuration;

namespace monoservicestack
{
	public class AppHost : AppHostBase
	{
		public AppHost ()
			: base("Hellow Web Services", typeof(HelloService).Assembly)
		{
		}

		public override void Configure(Funq.Container container)
		{
			// Setup the JSON formatting options
			ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;

			// Setup the database connection
			string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
			container.Register<IDbConnectionFactory>(new OrmLiteConnectionFactory(connectionString, MySqlDialect.Provider));
		}
	}
}


