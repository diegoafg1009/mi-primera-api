using ProyectoFinal.Model;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinal.Repository
{
    public class ProductHandler : DbHandler
    {
        public static void InsertProduct(Product product)
        {
            string queryInsert = "INSERT INTO Producto (Descripciones, Costo, PrecioVenta, Stock, idUsuario) VALUES (@description, @purchasePrice, @salePrice, @stock, @userId)";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlParameter DecriptionParameter = new SqlParameter("description", SqlDbType.VarChar) { Value = product.Description };
                SqlParameter pPriceParameter = new SqlParameter("purchasePrice", SqlDbType.Float) { Value = product.PurchasePrice };
                SqlParameter sPriceParameter = new SqlParameter("salePrice", SqlDbType.Float) { Value = product.SalePrice };
                SqlParameter stockParameter = new SqlParameter("stock", SqlDbType.Int) { Value = product.Stock };
                SqlParameter userIdParameter = new SqlParameter("userId", SqlDbType.BigInt) { Value = product.UserId };
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {

                    sqlCommand.Parameters.Add(DecriptionParameter);
                    sqlCommand.Parameters.Add(pPriceParameter);
                    sqlCommand.Parameters.Add(sPriceParameter);
                    sqlCommand.Parameters.Add(stockParameter);
                    sqlCommand.Parameters.Add(userIdParameter);
                    sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
        }

        public static void UpdateProduct(Product product)
        {
            string queryUpdate = "UPDATE Producto SET Descripciones = @description, Costo = @purchasePrice, PrecioVenta = @salePrice, Stock = @stock, idUsuario = @userId  WHERE Id = @id";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlParameter DecriptionParameter = new SqlParameter("description", SqlDbType.VarChar) { Value = product.Description };
                SqlParameter pPriceParameter = new SqlParameter("purchasePrice", SqlDbType.Float) { Value = product.PurchasePrice };
                SqlParameter sPriceParameter = new SqlParameter("salePrice", SqlDbType.Float) { Value = product.SalePrice };
                SqlParameter stockParameter = new SqlParameter("stock", SqlDbType.Int) { Value = product.Stock };
                SqlParameter userIdParameter = new SqlParameter("userId", SqlDbType.BigInt) { Value = product.UserId };
                SqlParameter idParameter = new SqlParameter("id", SqlDbType.BigInt) { Value = product.ProductId };
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                {

                    sqlCommand.Parameters.Add(DecriptionParameter);
                    sqlCommand.Parameters.Add(pPriceParameter);
                    sqlCommand.Parameters.Add(sPriceParameter);
                    sqlCommand.Parameters.Add(stockParameter);
                    sqlCommand.Parameters.Add(userIdParameter);
                    sqlCommand.Parameters.Add(idParameter);
                    sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
        }

        public static void DeleteProduct(int id)
        {
            string queryDelete = "DELETE FROM Producto WHERE Id = @id";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                {

                    sqlCommand.Parameters.Add(new SqlParameter("id", SqlDbType.BigInt) { Value = id });
                    sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
        }
    }
}
