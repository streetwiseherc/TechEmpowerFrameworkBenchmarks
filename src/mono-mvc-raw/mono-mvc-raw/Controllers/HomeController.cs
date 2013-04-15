using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace monomvcraw.Controllers
{
	public class HomeController : Controller
	{
		// Database connection
		private static readonly string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
		
		// Database details
		private const string DB_QUERY = "SELECT * FROM World WHERE id = @id";
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
			
			using (MySqlConnection connection = new MySqlConnection(ConnectionString)) 
			{
				connection.Open();
				
				using (MySqlCommand command = new MySqlCommand(DB_QUERY, connection)) 
				{
					command.Prepare();
					command.Parameters.Add("@id", MySqlDbType.Int32);
					
					for (int i = 0; i < count; i++) 
					{
						int id = random.Next(1, DB_ROWS);
						command.Parameters["@id"].Value = id;
						
						using (MySqlDataReader reader = command.ExecuteReader()) 
						{
							if (reader.Read())
							{
								worlds[i] = new World(id, reader.GetInt32("randomNumber"));
							}
						}
					}
				}
			}
			
			return Json(worlds, JsonRequestBehavior.AllowGet);
		}
	}
}

