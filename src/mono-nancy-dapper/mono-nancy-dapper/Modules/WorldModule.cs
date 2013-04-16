using Dapper;
using MySql.Data.MySqlClient;
using Nancy;
using System;
using System.Configuration;
using System.Linq;

namespace mononancydapper
{
	public class WorldModule : NancyModule	
	{
		// Database connection 
		private static readonly string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
		
		// Database details
		private const string DB_QUERY = "SELECT * FROM World WHERE id = @id";
		private const int DB_ROWS = 10000;

		public WorldModule ()
		{
			Get[@"/db/(?<queries>[\d]{1,3})"] = parameters => {

				int queries = Convert.ToInt32((string) parameters.queries);

				int count = queries.Clamp(1, 500);
				World[] worlds = new World[count];
				Random random = new Random();
				
				using (MySqlConnection connection = new MySqlConnection(ConnectionString)) 
				{
					connection.Open();
					
					for (int i = 0; i < count; i++) 
					{
						int id = random.Next(1, DB_ROWS);
						worlds[i] = connection.Query<World>(DB_QUERY, new { id = id }).FirstOrDefault();
					}
				}

				return Response.AsJson(worlds);
			};
		}
	}
}

