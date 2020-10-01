using Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class UserConnection
    {
        #region "PATRON SINGLETON"
        private static UserConnection userConnection = null;
        private UserConnection() { }
        public static UserConnection GetInstance()
        {
            if(userConnection == null)
            {
                userConnection = new UserConnection();
            }
            return userConnection;
        }
        #endregion

        // METODO DE LOGIN
        public User Login(String user, String pass)
        {
            SqlConnection connection = null;
            SqlDataReader reader = null;
            SqlCommand command = null;
            User objUser = null;

            try
            {
                connection = Connection.GetInstance().ConnectionDB();
                command = new SqlCommand("SP_ACCESSLOGIN", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Email", user.Trim());
                command.Parameters.AddWithValue("@Password", pass.Trim());

                connection.Open(); // ABRIENDO LA CONEXION
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    objUser = new User();
                    objUser.Role = new Role();
                    objUser.IdUser = Convert.ToInt32(reader["idUser"].ToString());
                    objUser.Email = reader["email"].ToString();
                    objUser.Password = reader["password"].ToString();
                    objUser.Token = reader["token"].ToString();
                    objUser.Status = Convert.ToBoolean(reader["status"]);
                    objUser.Role.IdRol = Convert.ToInt32(reader["role"].ToString());
                }
            } catch(Exception e)
            {
                objUser = null;
                throw e;
            }
            finally
            {
                connection.Close(); // CERRANDO LA CONEXION
            }
            return objUser;
        }

    }
}
