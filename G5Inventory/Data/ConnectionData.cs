using System.Data.SqlClient;
using System.Data;

namespace G5Inventory.Data
{
    public class ConnectionData
    {
        private static string connectionString = "Data Source=DPCA\\U20210463;Initial Catalog=G5Inventory;Integrated Security=True;Encrypt=False";

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
