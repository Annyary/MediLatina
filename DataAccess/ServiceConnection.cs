using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class ServiceConnection
    {
        #region "PATRON SINGLETON"
        private static ServiceConnection serviceConnection = null;
        private ServiceConnection() { }
        public static ServiceConnection GetInstance()
        {
            if (serviceConnection == null)
            {
                serviceConnection = new ServiceConnection();
            }
            return serviceConnection;
        }
        #endregion

        // METODO DE INSERTAR SERVICIO
        public bool InsertService(Service objService)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            bool response = false;

            try
            {
                connection = Connection.GetInstance().ConnectionDB();
                command = new SqlCommand("SP_INSERTSERVICE", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", objService.Name);
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

        public List<Service> ListService()
        {
            List<Service> listService = new List<Service>();
            SqlConnection connection = null;
            SqlCommand command = null;
            Service service;
            SqlDataReader reader;

            try
            {
                connection = Connection.GetInstance().ConnectionDB();
                command = new SqlCommand("SP_LISTARSERVICIOS", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    service = new Service
                    {
                        IdService = Convert.ToInt32(reader["idService"]),
                        Name = reader["name"].ToString()
                    };
                    // AGREGAR EL SERVICIO A LA LISTA
                    listService.Add(service);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return listService;
        }
    }
}
