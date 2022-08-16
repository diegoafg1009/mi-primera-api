using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinal
{
    public class ProductSoldHandler : DbHandler
    {
        public static List<ProductSold> GetProducts(int userId)
        {
            List<ProductSold> productsSold = new List<ProductSold>();
            ProductSold productSold;
            string querySelect = "SELECT DISTINCT pv.Id, pv.Stock, pv.IdProducto, pv.IdVenta FROM ProductoVendido pv " +
                "INNER JOIN Producto p ON p.Id = pv.IdProducto WHERE p.IdUsuario = @userId";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {

                using (SqlCommand sqlCommand = new SqlCommand(querySelect, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.Parameters.Add(new SqlParameter("userId", SqlDbType.BigInt) { Value = userId });

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                productSold = new ProductSold();
                                productSold.Id = Convert.ToInt32(dataReader["Id"]);
                                productSold.Stock = Convert.ToInt32(dataReader["Stock"]);
                                productSold.ProductId = Convert.ToInt32(dataReader["IdProducto"]);
                                productSold.SaleId = Convert.ToInt32(dataReader["IdVenta"]);
                                productsSold.Add(productSold);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return productsSold;
        }

    }
}