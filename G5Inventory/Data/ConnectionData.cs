using System.Data.SqlClient;
using System.Data;

namespace G5Inventory.Data
{
    public class ConnectionData
    {
<<<<<<< HEAD
        private static string connectionString = "Data Source=AARONLAPTOP\\CONNECT;Initial Catalog=G5Inventory;Integrated Security=True;Encrypt=False;";
=======
        private static string connectionString = "Data Source=U20210475\\SQLEXPRESS;Initial Catalog=G5Inventory;Integrated Security=True;Encrypt=False";
>>>>>>> 6e33593 (Parte de Carlos)

        public static string Connection()
        {
            return connectionString;
        }

        public static void ExecuteQuery(string query)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }
	}
}
