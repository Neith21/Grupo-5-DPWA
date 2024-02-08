using G5Inventory.Models;
using System.Data;
using System.Data.SqlClient;

namespace G5Inventory.Data
{
    public class CategoryData
    {
        string connectionString = @"Data Source=AARONLAPTOP\CONNECT;Initial Catalog=G5Inventory;Integrated Security=True;Encrypt=False;";

        public IEnumerable<CategoryModel> GetAll()
        {
            List<CategoryModel> categoryList = new List<CategoryModel>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT IdCategory, CategoryName, CategoryInfo, CategoryCode, CategoryStatus FROM Category;";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CategoryModel categoryModel = new CategoryModel();
                            categoryModel.IdCategory = Convert.ToInt32(reader["IdCategory"]);
                            categoryModel.CategoryName = reader["CategoryName"].ToString();
                            categoryModel.CategoryInfo = reader["CategoryInfo"].ToString();
                            categoryModel.CategoryCode = reader["CategoryCode"].ToString();
                            categoryModel.CategoryStatus = reader["CategoryStatus"].ToString();

                            categoryList.Add(categoryModel);
                        }
                    }
                }
            }

            return categoryList;
        }

        public CategoryModel? GetById(int id)
        {
            CategoryModel categoryModel = new CategoryModel();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT IdCategory, CategoryName, CategoryInfo, CategoryCode, CategoryStatus FROM Category
                                            WHERE IdCategory = @IdCategory";

                    command.Parameters.AddWithValue("@IdCategory", id);

                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categoryModel.IdCategory = Convert.ToInt32(reader["IdCategory"]);
                            categoryModel.CategoryName = reader["CategoryName"].ToString();
                            categoryModel.CategoryInfo = reader["CategoryInfo"].ToString();
                            categoryModel.CategoryCode = reader["CategoryCode"].ToString();
                            categoryModel.CategoryStatus = reader["CategoryStatus"].ToString();
                        }
                    }
                }
            }

            return categoryModel;
        }

        public void Add(CategoryModel category)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Category VALUES(@CategoryName, @CategoryInfo, @CategoryCode, @CategoryStatus)";

                    command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                    command.Parameters.AddWithValue("@CategoryInfo", category.CategoryInfo);
                    command.Parameters.AddWithValue("@CategoryCode", category.CategoryCode);
                    command.Parameters.AddWithValue("@CategoryStatus", category.CategoryStatus);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(CategoryModel category)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Category SET CategoryName = @CategoryName, 
                                            CategoryInfo = @CategoryInfo,
                                            CategoryCode = @CategoryCode,
                                            CategoryStatus = @CategoryStatus
                                            WHERE IdCategory = @IdCategory";

                    command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                    command.Parameters.AddWithValue("@CategoryInfo", category.CategoryInfo);
                    command.Parameters.AddWithValue("@CategoryCode", category.CategoryCode);
                    command.Parameters.AddWithValue("@CategoryStatus", category.CategoryStatus);
                    command.Parameters.AddWithValue("@IdCategory", category.IdCategory);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(CategoryModel category)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"DELETE FROM Category WHERE IdCategory = @IdCategory";

                    command.Parameters.AddWithValue("@IdCategory", category.IdCategory);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

