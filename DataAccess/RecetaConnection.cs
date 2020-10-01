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
    public class RecetaConnection
    {
        #region "PATRON SINGLETON"
        private static RecetaConnection recetaConnection = null;
        private RecetaConnection() { }
        public static RecetaConnection GetInstance()
        {
            if (recetaConnection == null)
            {
                recetaConnection = new RecetaConnection();
            }
            return recetaConnection;
        }
        #endregion

        // METODO DE INSERTAR RECETA
        public bool InsertReceta(Receta objReceta)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            bool response = false;

            try
            {
                connection = Connection.GetInstance().ConnectionDB();
                command = new SqlCommand("SP_INSERTRECETA", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@farmaco", objReceta.Farmaco.idVademecum);
                command.Parameters.AddWithValue("@paciente", objReceta.Pacient.IdPacient);
                command.Parameters.AddWithValue("@doctor", objReceta.Doctor.IdDoctor);
                command.Parameters.AddWithValue("@presentacion", objReceta.Presentacion.idPresentacion);
                command.Parameters.AddWithValue("@cantidad", objReceta.Cantidad);
                command.Parameters.AddWithValue("@fecha_emision", objReceta.FechaEmision);

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

        // METODO PARA LISTAR LAS RECETAS

        public List<Receta> ListReceta()
        {
            List<Receta> list = new List<Receta>();
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;

            // instancias
            //Farmaco farmaco;
            //Doctor doctor;
            //Presentacion presentacion;

            try
            {
                connection = Connection.GetInstance().ConnectionDB();
                command = new SqlCommand("SP_LISTRECETA", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Receta objReceta = new Receta();
                    objReceta.Doctor = new Doctor();
                    objReceta.Farmaco = new Farmaco();
                    objReceta.Presentacion = new Presentacion();
                    objReceta.IdReceta = DBHelper.ReadNullSafeInt(reader["idReceta"].ToString());
                    objReceta.Doctor.IdDoctor = DBHelper.ReadNullSafeInt(reader["doctor"].ToString());
                    objReceta.Farmaco.idVademecum = DBHelper.ReadNullSafeInt(reader["farmaco"].ToString());
                    objReceta.Presentacion.idPresentacion = DBHelper.ReadNullSafeInt(reader["presentacion"].ToString());
                    objReceta.Cantidad = DBHelper.ReadNullSafeInt(reader["cantidad"].ToString());
                    objReceta.FechaEmision = DBHelper.ReadNullSafeDateTime(reader["fecha_emision"].ToString());

                    // AGREGANDO A LA LISTA
                    list.Add(objReceta);
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
