using ProyectoFinal.Model;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinal.Repository
{
    public class SaleHandler : DbHandler
    {
        public static List<Sale> GetSales(int userId)
        {
            List<Sale> sales = new List<Sale>();
            Sale sale;
            string querySelect = "SELECT DISTINCT v.Id, v.Comentarios FROM Venta v INNER JOIN ProductoVendido pv ON pv.IdVenta = v.Id INNER JOIN Producto p ON p.Id = pv.IdProducto WHERE p.IdUsuario = @userId";
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
                                sale = new Sale();
                                sale.SaleId = Convert.ToInt32(dataReader["Id"]);
                                sale.Comments = dataReader.GetString(1);
                                sales.Add(sale);
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return sales;
        }

        public static void InsertSale(int userId,  ref int newId)
        {
            string commentary = "Efectuado por Usuario " + userId.ToString();
            string queryInsert = "INSERT INTO Venta (Comentarios) VALUES (@commentary); SELECT SCOPE_IDENTITY()" ;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlParameter commentaryParameter = new SqlParameter("commentary", SqlDbType.VarChar) { Value = commentary};
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(commentaryParameter);
                    newId = Convert.ToInt32(sqlCommand.ExecuteScalar());
                }
                sqlConnection.Close();
            }
        }
    }
}
