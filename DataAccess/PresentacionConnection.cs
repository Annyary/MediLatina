using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace DataAccess
{
    public class PresentacionConnection
    {

        #region "PATRON SINGLETON"
        private static PresentacionConnection presentacionConnection = null;
        private PresentacionConnection() { }
        public static PresentacionConnection GetInstance()
        {
            if (presentacionConnection == null)
            {
                presentacionConnection = new PresentacionConnection();
            }
            return presentacionConnection;
        }
        #endregion

        // INSERTAR UNA PRESENTACION
        public bool InsertPresentacion(Presentacion objPresentacion)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            bool response = false;

            try
            {
                connection = Connection.GetInstance().ConnectionDB();
                command = new SqlCommand("SP_INSERTPRESENTACION", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@tipo", objPresentacion);

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

        // LISTAR PRESENTACION
        public List<Presentacion> ListPresentacion()
        {
            List<Presentacion> list = new List<Presentacion>();
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;

            try
            {
                connection = Connection.GetInstance().ConnectionDB();
                command = new SqlCommand("SP_LISTARPRESENTACION", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Presentacion objPresentacion = new Presentacion
                    {
                        idPresentacion = DBHelper.ReadNullSafeInt(reader["idPresentacion"]),
                        tipo = DBHelper.ReadNullSafeString(reader["tipo"])
                    };
                    list.Add(objPresentacion);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
    }
}
