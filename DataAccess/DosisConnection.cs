using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DosisConnection
    {

        #region "PATRON SINGLETON"
        private static DosisConnection dosisConnection = null;
        private DosisConnection() { }
        public static DosisConnection GetInstance()
        {
            if (dosisConnection == null)
            {
                dosisConnection = new DosisConnection();
            }
            return dosisConnection;
        }
        #endregion

        public bool InsertDosis(Dosis objDosis)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            bool response = false;

            try
            {
                connection = Connection.GetInstance().ConnectionDB();
                command = new SqlCommand("SP_INSERTDOSIS", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@farmaco", objDosis.Farmaco.idVademecum);
                command.Parameters.AddWithValue("@presentacion", objDosis.Presentacion.idPresentacion);
                command.Parameters.AddWithValue("@precio", objDosis.Precio);

                connection.Open();
                int rows = command.ExecuteNonQuery();

                if (rows > 0) response = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
            return response;
        }
    }
}
