using ProyectoFinal.Model;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinal.Repository
{
    public class UserHandler : DbHandler
    {
        public static User GetUser(string userName)
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
                        if (dataReader.Read())
                        {
                            user.UserId = Convert.ToInt32(dataReader["Id"]);
                            user.UserName = dataReader["NombreUsuario"].ToString();
                            user.FirstName = dataReader["Nombre"].ToString();
                            user.LastName = dataReader["Apellido"].ToString();
                            user.Password = dataReader["Contraseña"].ToString();
                            user.Email = dataReader["Mail"].ToString();
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
            string querySelect = "SELECT * FROM Usuario WHERE NombreUsuario = @userName and Contraseña = @pass";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {

                using (SqlCommand sqlCommand = new SqlCommand(querySelect, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.Parameters.Add(new SqlParameter("userName", SqlDbType.VarChar) { Value = userName });
                    sqlCommand.Parameters.Add(new SqlParameter("pass", SqlDbType.VarChar) { Value = pass });

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            user.UserId = Convert.ToInt32(dataReader["Id"]);
                            user.UserName = dataReader["NombreUsuario"].ToString();
                            user.FirstName = dataReader["Nombre"].ToString();
                            user.LastName = dataReader["Apellido"].ToString();
                            user.Password = dataReader["Contraseña"].ToString();
                            user.Email = dataReader["Mail"].ToString();
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return user;
        }

        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();
            User user;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                user = new User();

                                user.UserId = Convert.ToInt32(dataReader["Id"]);
                                user.UserName = dataReader["NombreUsuario"].ToString();
                                user.FirstName = dataReader["Nombre"].ToString();
                                user.LastName = dataReader["Apellido"].ToString();
                                user.Password = dataReader["Contraseña"].ToString();
                                user.Email = dataReader["Mail"].ToString();

                                users.Add(user);
                            }
                        }
                    }
                }
            }


                return users;
        }

        public static void DeleteUser(int id)
        {
            string queryDelete = "DELETE FROM Usuario WHERE Id = @id";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                {
                    
                    sqlCommand.Parameters.Add(new SqlParameter("id", SqlDbType.BigInt) { Value = id});
                    sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
        }

        public static void UpdateUser(User user)
        {
            string queryUpdate = "UPDATE Usuario SET Nombre = @firstName, Apellido = @lastName, NombreUsuario = @userName, Contraseña = @pass, Mail = @mail  WHERE Id = @id";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlParameter firstNameParameter = new SqlParameter("firstName", SqlDbType.VarChar) { Value = user.FirstName};
                SqlParameter lastNameParameter = new SqlParameter("lastName", SqlDbType.VarChar) { Value = user.LastName };
                SqlParameter userNameParameter = new SqlParameter("userName", SqlDbType.VarChar) { Value = user.UserName };
                SqlParameter passParameter = new SqlParameter("pass", SqlDbType.VarChar) { Value = user.Password };
                SqlParameter mailParameter = new SqlParameter("mail", SqlDbType.VarChar) { Value = user.Email};
                SqlParameter idParameter = new SqlParameter("id", SqlDbType.BigInt) { Value = user.UserId };
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                {

                    sqlCommand.Parameters.Add(firstNameParameter);
                    sqlCommand.Parameters.Add(lastNameParameter);
                    sqlCommand.Parameters.Add(userNameParameter);
                    sqlCommand.Parameters.Add(passParameter);
                    sqlCommand.Parameters.Add(mailParameter);
                    sqlCommand.Parameters.Add(idParameter);
                    sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
        }

        public static void InsertUser(User user)
        {
            string queryInsert = "INSERT INTO Usuario (Nombre, Apellido, NombreUsuario, Contraseña, mail) VALUES (@firstName, @lastName, @userName, @pass, @mail)";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlParameter firstNameParameter = new SqlParameter("firstName", SqlDbType.VarChar) { Value = user.FirstName };
                SqlParameter lastNameParameter = new SqlParameter("lastName", SqlDbType.VarChar) { Value = user.LastName };
                SqlParameter userNameParameter = new SqlParameter("userName", SqlDbType.VarChar) { Value = user.UserName };
                SqlParameter passParameter = new SqlParameter("pass", SqlDbType.VarChar) { Value = user.Password };
                SqlParameter mailParameter = new SqlParameter("mail", SqlDbType.VarChar) { Value = user.Email };
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {

                    sqlCommand.Parameters.Add(firstNameParameter);
                    sqlCommand.Parameters.Add(lastNameParameter);
                    sqlCommand.Parameters.Add(userNameParameter);
                    sqlCommand.Parameters.Add(passParameter);
                    sqlCommand.Parameters.Add(mailParameter);
                    sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
        }
    }
}
