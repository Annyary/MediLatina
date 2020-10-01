using System.Data.SqlClient;

namespace DataAccess
{
    public class Connection
    {
        #region "PATRON SINGLETON"
        private static Connection connection = null;
        private Connection() { }
        public static Connection GetInstance()
        {
            if (connection == null)
            {
                connection = new Connection();
            }
            return connection;
        }
        #endregion

        public SqlConnection ConnectionDB()
        {
            SqlConnection connection = new SqlConnection();
            //CONEXION CON SQL SERVER
            connection.ConnectionString = "Data Source=34.70.203.70; Initial Catalog=medilatina; Persist Security Info=True; User ID=sqlserver; Password=admin";
            return connection;
        }

    }
}
