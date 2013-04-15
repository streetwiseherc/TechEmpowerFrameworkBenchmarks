using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace monomvcnhibernate.Controllers
{
	public class HomeController : Controller
	{
		// Database session factory
		private static ISessionFactory CreateSessionFactory()
		{
			string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

			return Fluently.Configure()
				.Database(MySQLConfiguration.Standard.ConnectionString(connectionString))
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<World>())
				.BuildSessionFactory();
		}

		// Database details
		private const int DB_ROWS = 10000;

		// JSON Response
		public JsonResult Json()
		{
			return Json (new { message = "Hello World!" }, JsonRequestBehavior.AllowGet);
		}

		// Database (single query + multiple queries)
		public JsonResult Db(int queries = 1) 
		{
			int count = queries.Clamp(1, 500);
			World[] worlds = new World[count];
			Random random = new Random();  

			ISessionFactory sessionFactory = CreateSessionFactory();

			using (ISession session = sessionFactory.OpenSession())
			{
				for (int i = 0; i < count; i++) 
				{
					int id = random.Next(1, DB_ROWS);
					worlds[i] = session.Get<World>(id);
				}
			}

			return Json(worlds, JsonRequestBehavior.AllowGet);
		}
	}
}

