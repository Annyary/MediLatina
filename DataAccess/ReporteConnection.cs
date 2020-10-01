using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace DataAccess
{
    public class ReporteConnection
    {
        #region "PATRON SINGLETON"
        private static ReporteConnection reporteConnection = null;
        private ReporteConnection() { }
        public static ReporteConnection GetInstance()
        {
            if (reporteConnection == null)
            {
                reporteConnection = new ReporteConnection();
            }
            return reporteConnection;
        }
        #endregion

        // METODO DE LISTAR REPORTE
        public List<Reporte> ListReporte()
        {
            List<Reporte> list = new List<Reporte>();
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;

            // instancias
            Pacient paciente;
            Service service;
            Farmaco farmaco;
            Presentacion presentacion;

            try
            {
                connection = Connection.GetInstance().ConnectionDB();
                command = new SqlCommand("SP_LISTREPORTES", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    paciente = new Pacient();
                    service = new Service();
                    farmaco = new Farmaco();
                    presentacion = new Presentacion();

                    Reporte objReporte = new Reporte();
                    objReporte.Paciente = new Pacient();
                    objReporte.Servicio = new Service();
                    objReporte.Farmaco = new Farmaco();
                    objReporte.Presentacion = new Presentacion();

                    objReporte.IdReporte = DBHelper.ReadNullSafeInt(reader["idReporte"].ToString());
                    objReporte.Paciente.IdPacient = DBHelper.ReadNullSafeInt(reader["paciente"].ToString());
                    objReporte.Servicio.IdService = DBHelper.ReadNullSafeInt(reader["servicio"].ToString());
                    objReporte.Farmaco.idVademecum = DBHelper.ReadNullSafeInt(reader["farmaco"].ToString());
                    objReporte.Presentacion.idPresentacion = DBHelper.ReadNullSafeInt(reader["presentacion"].ToString());
                    objReporte.Cantidad = DBHelper.ReadNullSafeInt(reader["cantidad"].ToString());

                    // AGREGANDO A LA LISTA
                    list.Add(objReporte);
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

        // METODO DE INSERTAR VADEMECUM
        public bool InsertReporte(Reporte objReporte)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            bool response = false;

            try
            {
                connection = Connection.GetInstance().ConnectionDB();
                command = new SqlCommand("SP_INSERTREPORT", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@paciente", objReporte.Paciente.IdPacient);
                command.Parameters.AddWithValue("@servicio", objReporte.Servicio.IdService);
                command.Parameters.AddWithValue("@farmaco", objReporte.Farmaco.idVademecum);
                command.Parameters.AddWithValue("@presentacion", objReporte.Presentacion.idPresentacion);
                command.Parameters.AddWithValue("@cantidad", objReporte.Cantidad);
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

        // CANTIDAD DE DOCTORES
        public int CantidadDoctores()
        {
            int cantidad = 0;
            SqlConnection connection = null;
            SqlCommand command = null;

            try
            {
                connection = Connection.GetInstance().ConnectionDB();
                command = new SqlCommand("SP_CANT_DOCTORES", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                cantidad = Convert.ToInt32(command.ExecuteScalar()); ;

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
            return cantidad;
        }

        // CANTIDAD DE SERVICIOS
        public int CantidadServicios()
        {
            int cantidad = 0;
            SqlConnection connection = null;
            SqlCommand command = null;

            try
            {
                connection = Connection.GetInstance().ConnectionDB();
                command = new SqlCommand("SP_CANT_SERVICIOS", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                cantidad = Convert.ToInt32(command.ExecuteScalar()); ;

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
            return cantidad;
        }


        // CANTIDAD DE PACIENTES
        public int CantidadPacientes()
        {
            int cantidad = 0;
            SqlConnection connection = null;
            SqlCommand command = null;

            try
            {
                connection = Connection.GetInstance().ConnectionDB();
                command = new SqlCommand("SP_CANT_PACIENTES", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                cantidad = Convert.ToInt32(command.ExecuteScalar()); ;

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
            return cantidad;
        }

    }
}