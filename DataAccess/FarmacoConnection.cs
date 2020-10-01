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
    public class FarmacoConnection
    {
        #region "PATRON SINGLETON"
        private static FarmacoConnection farmacoConnection = null;
        private FarmacoConnection() { }
        public static FarmacoConnection GetInstance()
        {
            if (farmacoConnection == null)
            {
                farmacoConnection = new FarmacoConnection();
            }
            return farmacoConnection;
        }
        #endregion

        // METODO DE INSERTAR VADEMECUM
        public bool InsertFarmaco(Farmaco objFarmaco)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            bool response = false;

            try
            {
                connection = Connection.GetInstance().ConnectionDB();
                command = new SqlCommand("SP_INSERTVADEMECUM", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@num_registro", objFarmaco.num_registro);
                command.Parameters.AddWithValue("@nombre_comercial", objFarmaco.nombre_comercial);
                command.Parameters.AddWithValue("@nombre_clinico", objFarmaco.nombre_clinico);
                command.Parameters.AddWithValue("@compuesto_quimico", objFarmaco.compuesto_quimico);
                command.Parameters.AddWithValue("@ubicacion", objFarmaco.ubicacion);
                command.Parameters.AddWithValue("@proveedor", objFarmaco.proveedor);

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

        // METODO DE LISTAR VADEMECUM
        public List<Farmaco> ListFarmacos()
        {
            List<Farmaco> list = new List<Farmaco>();
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;

            try
            {
                connection = Connection.GetInstance().ConnectionDB();
                command = new SqlCommand("SP_LISTARVADEMECUM", connection);
                connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Farmaco objFarmaco = new Farmaco
                    {
                        idVademecum = DBHelper.ReadNullSafeInt(reader["idVademecum"]),
                        num_registro = DBHelper.ReadNullSafeString(reader["num_registro"]),
                        nombre_comercial = DBHelper.ReadNullSafeString(reader["nombre_comercial"]),
                        nombre_clinico = DBHelper.ReadNullSafeString(reader["nombre_clinico"]),
                        compuesto_quimico = DBHelper.ReadNullSafeString(reader["compuesto_quimico"]),
                        ubicacion = DBHelper.ReadNullSafeString(reader["ubicacion"]),
                        proveedor = DBHelper.ReadNullSafeString(reader["proveedor"])
                    };
                    list.Add(objFarmaco);
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
