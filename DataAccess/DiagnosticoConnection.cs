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
    public class DiagnosticoConnection
    {
        #region "PATRON SINGLETON"
        private static DiagnosticoConnection diagnosticoConnection = null;
        private DiagnosticoConnection() { }
        public static DiagnosticoConnection GetInstance()
        {
            if (diagnosticoConnection == null)
            {
                diagnosticoConnection = new DiagnosticoConnection();
            }
            return diagnosticoConnection;
        }
        #endregion

        public bool InsertDiagnostico(Diagnostico objDiagnostico)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            bool response = false;

            try
            {
                connection = Connection.GetInstance().ConnectionDB();
                command = new SqlCommand("SP_INSERTDIAGNOSTICO", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idinternamiento", objDiagnostico.Internado.IdInternamiento);
                command.Parameters.AddWithValue("@informe", objDiagnostico.Informe);

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

        public bool LeerInforme(Diagnostico objDiagnostico)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            bool response = false;

            try
            {
                connection = Connection.GetInstance().ConnectionDB();
                command = new SqlCommand("SP_INSERTDIAGNOSTICO", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idinternamiento", objDiagnostico.Internado.IdInternamiento);
                command.Parameters.AddWithValue("@informe", objDiagnostico.Informe);

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
