using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web;

namespace monohttphandler
{
	public class DbHandler : IHttpHandler
	{
		// Database connection
		private static readonly string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
		
		// Database details
		private const string DB_QUERY = "SELECT * FROM World WHERE id = @id";
		private const int DB_ROWS = 10000;

		public bool IsReusable
		{
			get { return false; }
		}
		
		public void ProcessRequest(HttpContext context)
		{
			int count = context.Request.GetQueryStringInteger("queries", 1).Clamp(1, 500);
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

			JsonHelpers.WriteJson(worlds, context);
		}
	}
}
