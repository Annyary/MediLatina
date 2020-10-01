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
    public class InternadoConnection
    {
        #region "PATRON SINGLETON"
        private static InternadoConnection internadoConnection = null;
        private InternadoConnection() { }
        public static InternadoConnection GetInstance()
        {
            if (internadoConnection == null)
            {
                internadoConnection = new InternadoConnection();
            }
            return internadoConnection;
        }
        #endregion

        // METODO PARA INSERTAR UN NUEVO INTERNADO
        public bool InsertInternado(Internado objInternado)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            bool response = false;

            try
            {
                connection = Connection.GetInstance().ConnectionDB();
                command = new SqlCommand("SP_INSERTINTERNADO", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@paciente", objInternado.Paciente.IdPacient);
                command.Parameters.AddWithValue("@servicio", objInternado.Servicio.IdService);
                command.Parameters.AddWithValue("@fechaIngreso", objInternado.FechaIngreso);
                //command.Parameters.AddWithValue("@fechaSalida", objInternado.FechaSalida);

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

        // METODO PARA LISTAR LAS PERSONAS INTERNADAS
        public List<Internado> ListInternados()
        {
            List<Internado> list = new List<Internado>();
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;

            //INSTANCIAS
            Pacient paciente;
            Service servicio;

            try
            {
                connection = Connection.GetInstance().ConnectionDB();
                command = new SqlCommand("SP_LISTINTERNADO", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    paciente = new Pacient();
                    servicio = new Service();

                    Internado objInternado = new Internado();
                    objInternado.Paciente = new Pacient();
                    objInternado.Servicio = new Service();

                    objInternado.IdInternamiento = DBHelper.ReadNullSafeInt(reader["idInternamiento"]);
                    objInternado.Paciente.IdPacient = DBHelper.ReadNullSafeInt(reader["paciente"]);
                    objInternado.Servicio.IdService = DBHelper.ReadNullSafeInt(reader["servicio"]);
                    objInternado.FechaIngreso = DBHelper.ReadNullSafeDateTime(reader["fecha_ingreso"]);
                    objInternado.FechaSalida = DBHelper.ReadNullSafeDateTime(reader["fecha_salida"]);

                    // AGREGAR A LA LISTA
                    list.Add(objInternado);
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
