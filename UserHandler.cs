using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinal
{
    public class UserHandler : DbHandler
    {
        public static User GetUsuarios(string userName)
        {
            User user = new User();
            string querySelect = "SELECT * FROM Usuario WHERE NombreUsuario = @userName";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {

                using (SqlCommand sqlCommand = new SqlCommand(querySelect, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.Parameters.Add(new SqlParameter("userName", SqlDbType.VarChar) { Value = userName});

                    using(SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            user.UserId = Convert.ToInt32(dataReader["Id"]);
                            user.FirstName = dataReader.GetString(1);
                            user.LastName = dataReader.GetString(2);
                            user.UserName = dataReader.GetString(3);
                            user.Password = dataReader.GetString(4);
                            user.Email = dataReader.GetString(5);
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return user;
        }

        public static User Login(string userName, string pass)
        {
            User user = new User();
            string querySelect = "SELECT * FROM Usuario WHERE NombreUsuario = @userName";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {

                using (SqlCommand sqlCommand = new SqlCommand(querySelect, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.Parameters.Add(new SqlParameter("userName", SqlDbType.VarChar) { Value = userName });

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.Read() && pass == dataReader.GetString(4))
                        {
                            user.UserId = Convert.ToInt32(dataReader["Id"]);
                            user.FirstName = dataReader.GetString(1);
                            user.LastName = dataReader.GetString(2);
                            user.UserName = dataReader.GetString(3);
                            user.Password = dataReader.GetString(4);
                            user.Email = dataReader.GetString(5);
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return user;
        }

        public void Delete()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryDelete = "DELETE FROM Usuario Where Id = @idUsuario";

                    double id = 1;

                    SqlParameter sqlParameter = new SqlParameter();

                    sqlParameter.ParameterName = "idUsuario";
                    sqlParameter.SqlDbType = SqlDbType.BigInt;
                    sqlParameter.Value = id;

                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(sqlParameter);
                        sqlCommand.ExecuteNonQuery();
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public void UpdatePass()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryUpdate = "UPDATE Usuario SET Contraseña = @newPass Where Id = @idUsuario";

                    double newId = 1;
                    string newPass = "EstaEsUnaNuevaPass";

                    SqlParameter passParameter = new SqlParameter("pass", SqlDbType.VarChar);
                    passParameter.Value = newPass;

                    SqlParameter idParameter = new SqlParameter("idUsuario",SqlDbType.BigInt);
                    idParameter.Value = newId;

                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(idParameter);
                        sqlCommand.Parameters.Add(passParameter);
                        sqlCommand.ExecuteNonQuery();
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public void Add()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryInsert = "INSERT INTO Usuario (Nombre, Apellido, Contraseña, Mail) VALUES (@firstName, @lastName, @userName, @Password, @email)";

                    double id = 1;

                    SqlParameter sqlParameter = new SqlParameter();

                    sqlParameter.ParameterName = "idUsuario";
                    sqlParameter.SqlDbType = SqlDbType.BigInt;
                    sqlParameter.Value = id;

                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        sqlCommand.ExecuteScalar();
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

    }
}