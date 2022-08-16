using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinal
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
                            }
                        }
                    }


                    sqlConnection.Close();
                }
            }


            return sales;
        } 
    }
}