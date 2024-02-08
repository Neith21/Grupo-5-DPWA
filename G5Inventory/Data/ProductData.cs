using G5Inventory.Models;
using System.Data;
using System.Data.SqlClient;

namespace G5Inventory.Data
{
    public class ProductData
    {
        public IEnumerable<ProductModel> GetAll()
        {
            List<ProductModel> producstList = new List<ProductModel>();

            using (var connection = new SqlConnection(ConnectionData.Connection()))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT IdProduct, ProductName, Price, IdCategory, IdProvider, Expiration, Stock FROM Products";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductModel productModel = new ProductModel();
                            productModel.IdProduct = Convert.ToInt32(reader["IdProduct"]);
                            productModel.ProductName = reader["ProductName"].ToString();
                            productModel.Price = Convert.ToDecimal(reader["Price"]);
                            productModel.IdCategory = Convert.ToInt32(reader["IdCategory"]);
                            productModel.IdProvider = Convert.ToInt32(reader["IdProvider"]);
                            productModel.Expiration = reader["Expiration"].ToString();
                            productModel.Stock = Convert.ToInt32(reader["Stock"]);

                            producstList.Add(productModel);
                        }
                    }
                }
            }

            return producstList;
        }

        public void Add(ProductModel productModel)
        {
            string query = $@"INSERT INTO Products (ProductName, Price, IdCategory, IdProvider, Expiration, Stock) VALUES
                            ('{productModel.ProductName}',
                            {productModel.Price},
                            {productModel.IdCategory},
                            {productModel.IdProvider},
                            '{productModel.Expiration}',
                            {productModel.Stock})";

            ConnectionData.ExecuteQuery(query);
        }

        public void Edit(ProductModel productModel)
        {
			using (var connection = new SqlConnection(ConnectionData.Connection()))
			{
				connection.Open();

				using (var command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = @"UPDATE Products 
                                           SET ProductName = @ProductName,
                                           Price = @Price,
                                           IdCategory = @IdCategory,
                                           IdProvider = @IdProvider,
                                           Expiration = @Expiration,
                                           Stock = @Stock
                                           WHERE IdProduct = @IdProduct";

					command.Parameters.AddWithValue("@ProductName", productModel.ProductName);
					command.Parameters.AddWithValue("@Price", productModel.Price);
					command.Parameters.AddWithValue("@IdCategory", productModel.IdCategory);
					command.Parameters.AddWithValue("@IdProvider", productModel.IdProvider);
					command.Parameters.AddWithValue("@Expiration", productModel.Expiration);
					command.Parameters.AddWithValue("@Stock", productModel.Stock);
					command.Parameters.AddWithValue("@IdProduct", productModel.IdProduct);

					command.CommandType = CommandType.Text;

					command.ExecuteNonQuery();
				}
			}
		}

		public void Delete(int id)
		{
            using (var connection = new SqlConnection(ConnectionData.Connection()))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"DELETE FROM Products WHERE IdProduct = @IdProduct";
                    command.Parameters.AddWithValue("@IdProduct", id);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }
	}
}
