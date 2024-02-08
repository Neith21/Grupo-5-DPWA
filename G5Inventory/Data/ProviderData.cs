using G5Inventory.Models;
using System.Data.SqlClient;
using System.Data;

namespace G5Inventory.Data
{
    public class ProviderData
    {
        string connectionString = "Data Source=U20210475\\SQLEXPRESS;Initial Catalog=G5Inventory;Integrated Security=True;Encrypt=False";

        public IEnumerable<ProviderModel> GetAll()
        {
            List<ProviderModel> providerList = new List<ProviderModel>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT IdProvider, ProviderName, Phone, Email, Delivery FROM Providers;";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProviderModel providerModel = new ProviderModel();
                            providerModel.IdProvider = Convert.ToInt32(reader["IdProvider"]);
                            providerModel.ProviderName = reader["ProviderName"].ToString();
                            providerModel.Phone = reader["Phone"].ToString();
                            providerModel.Email = reader["Email"].ToString();
                            providerModel.Delivery = reader["Delivery"].ToString();

                            providerList.Add(providerModel);
                        }
                    }
                }
            }

            return providerList;
        }

        public ProviderModel? GetById(int id)
        {
            ProviderModel providerModel = new ProviderModel();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT IdProvider, ProviderName, Phone, Email, Delivery FROM Providers
                                            WHERE IdProvider = @IdProvider";

                    command.Parameters.AddWithValue("@IdProvider", id);

                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            providerModel.IdProvider = Convert.ToInt32(reader["IdProvider"]);
                            providerModel.ProviderName = reader["ProviderName"].ToString();
                            providerModel.Phone = reader["Phone"].ToString();
                            providerModel.Email = reader["Email"].ToString();
                            providerModel.Delivery = reader["Delivery"].ToString();
                        }
                    }
                }
            }

            return providerModel;
        }

        public void Add(ProviderModel provider)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Providers 
                                           VALUES(@ProviderName, @Phone, @Email, @Delivery)";

                    command.Parameters.AddWithValue("@ProviderName", provider.ProviderName);
                    command.Parameters.AddWithValue("@Phone", provider.Phone);
                    command.Parameters.AddWithValue("@Email", provider.Email);
                    command.Parameters.AddWithValue("@Delivery", provider.Delivery);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(ProviderModel provider)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Providers 
                                           SET ProviderName = @ProviderName,
                                           Phone = @Phone,
                                           Email = @Email,
                                           Delivery = @Delivery
                                           WHERE IdProvider = @IdProvider";

                    command.Parameters.AddWithValue("@ProviderName", provider.ProviderName);
                    command.Parameters.AddWithValue("@Phone", provider.Phone);
                    command.Parameters.AddWithValue("@Email", provider.Email);
                    command.Parameters.AddWithValue("@Delivery", provider.Delivery);
                    command.Parameters.AddWithValue("@IdProvider", provider.IdProvider);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"DELETE FROM Providers
                                           WHERE IdProvider = @IdProvider";

                    command.Parameters.AddWithValue("@IdProvider", id);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
