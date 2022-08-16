using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinal
{
    public class ProductHandler: DbHandler
    {
        public static List<Product> GetProducts(int userId)
        {
            List<Product> products = new List<Product>();
            Product product;
            string querySelect = "SELECT * FROM Producto WHERE IdUsuario = @userId";
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
                                product = new Product();
                                product.ProductId = Convert.ToInt32(dataReader["Id"]);
                                product.Description = dataReader.GetString(1);
                                product.PurchasePrice = Convert.ToInt32(dataReader["Costo"]);
                                product.SalePrice = Convert.ToInt32(dataReader["PrecioVenta"]);
                                product.Stock = Convert.ToInt32(dataReader["Stock"]);
                                product.UserId = Convert.ToInt32(dataReader["IdUsuario"]);
                                products.Add(product);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return products;
        }

        public List<string> GetDescriptionsWithDataReader()
        {
            List<string> descripciones = new List<string>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using(SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Producto", sqlConnection))
                {
                    sqlConnection.Open();

                    using(SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                descripciones.Add(dataReader.GetString(1));
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }
            return descripciones;
        }

        


        //public list<string> getdescriptionswithdataadapter()
        //{
        //    list<string> descripciones = new list<string>();
        //    using (sqlconnection sqlconnection = new sqlconnection(connectionstring))
        //    {
        //        sqldataadapter sqldataadapter = new sqldataadapter("select * from producto", sqlconnection);

        //        sqlconnection.open();

        //        dataset resultado = new dataset();
        //        sqldataadapter.fill(resultado);


        //        sqlconnection.close();
        //    }

        //    return descripciones;
        //}
        
        //public void Delete()
        //{
        //    using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
        //    {
        //        string queryDelete = "DELETE FROM Usuario Where Id = @idUsuario";

        //        double id = 1;

        //        SqlParameter sqlParameter = new SqlParameter;

        //        sqlParameter.ParameterName = "idUsuario";
        //        sqlParameter.SqlDbType = SqlDbType.BigInt;
        //        sqlParameter.Value = id;
                
        //        using(SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
        //        {
        //            sqlCommand.Parameters.Add(sqlParameter);
        //            int filasAfectadas = sqlCommand.ExecuteNonQuery();
        //        }
        //    }
        //}

    }
}