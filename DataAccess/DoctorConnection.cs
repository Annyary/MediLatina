using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace DataAccess
{
    public class DoctorConnection
    {
        #region "PATRON SINGLETON"
        private static DoctorConnection doctorConnection = null;
        private DoctorConnection() { }
        public static DoctorConnection GetInstance()
        {
            if (doctorConnection == null)
            {
                doctorConnection = new DoctorConnection();
            }
            return doctorConnection;
        }
        #endregion

        // METODO DE INSERTAR UN DOCTOR 
        public bool InsertDoctor(Doctor objDoctor)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            bool response = false;

            try
            {
                connection = Connection.GetInstance().ConnectionDB();
                command = new SqlCommand("SP_INSERTDOCTOR", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@num_colegiado", objDoctor.Num_colegiado);
                command.Parameters.AddWithValue("@name", objDoctor.Name);
                command.Parameters.AddWithValue("@address", objDoctor.Address);
                command.Parameters.AddWithValue("@telephone", objDoctor.Telephone);
                command.Parameters.AddWithValue("@servicio_adscrito", objDoctor.Service.IdService);
                command.Parameters.AddWithValue("@status", objDoctor.Status);

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

        // METODO PARA LISTAR LOS DOCTORES
        public List<Doctor> ListDoctors()
        {
            List<Doctor> list = new List<Doctor>();
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;
            Service service;

            try
            {
                connection = Connection.GetInstance().ConnectionDB();
                command = new SqlCommand("SP_LISTARDOCTORES", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Doctor objDoctor = new Doctor();
                    service = new Service();
                    objDoctor.Service = new Service();
                    objDoctor.IdDoctor = DBHelper.ReadNullSafeInt(reader["idDoctor"].ToString());
                    objDoctor.Num_colegiado = DBHelper.ReadNullSafeInt(reader["num_colegiado"].ToString());
                    objDoctor.Name = DBHelper.ReadNullSafeString(reader["name"]);
                    objDoctor.Address = DBHelper.ReadNullSafeString(reader["address"]);
                    objDoctor.Telephone = DBHelper.ReadNullSafeInt(reader["telephone"].ToString());
                    objDoctor.Status = DBHelper.ReadNullSafeBoolean(reader["status"].ToString());
                    objDoctor.Service.IdService = DBHelper.ReadNullSafeInt(reader["servicio_adscrito"].ToString());
                    // AGREGAR TODO A LA LISTA
                    list.Add(objDoctor);
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

        public List<Doctor> ListDoctorPorServicio(Doctor objDoctor)
        {
            List<Doctor> list = new List<Doctor>();
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;
            Service service;

            try
            {
                connection = Connection.GetInstance().ConnectionDB();
                command = new SqlCommand("SP_LISTARDOCTORSINTERNADO", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idservicio", objDoctor.Service.IdService);
                connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    objDoctor = new Doctor();
                    service = new Service();
                    objDoctor.Service = new Service();
                    objDoctor.IdDoctor = DBHelper.ReadNullSafeInt(reader["idDoctor"].ToString());
                    objDoctor.Num_colegiado = DBHelper.ReadNullSafeInt(reader["num_colegiado"].ToString());
                    objDoctor.Name = DBHelper.ReadNullSafeString(reader["name"]);
                    objDoctor.Address = DBHelper.ReadNullSafeString(reader["address"]);
                    objDoctor.Telephone = DBHelper.ReadNullSafeInt(reader["telephone"].ToString());
                    objDoctor.Status = DBHelper.ReadNullSafeBoolean(reader["status"].ToString());
                    objDoctor.Service.IdService = DBHelper.ReadNullSafeInt(reader["servicio_adscrito"].ToString());
                    // AGREGAR TODO A LA LISTA
                    list.Add(objDoctor);
                }
                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }

        }

        public Doctor BuscarDoctor(String id)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;
            Doctor objDoctor = null;
            Service service;
            try
            {
                connection = Connection.GetInstance().ConnectionDB();
                command = new SqlCommand("SP_BUSCARDOCTOR", connection);
                command.Parameters.AddWithValue("@NumColegiado", id);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    service = new Service();
                    objDoctor = new Doctor()
                    {
                        IdDoctor = DBHelper.ReadNullSafeInt(reader["idDoctor"].ToString()),
                        Num_colegiado = DBHelper.ReadNullSafeInt(reader["num_colegiado"].ToString()),
                        Name = DBHelper.ReadNullSafeString(reader["name"]),
                        Address = DBHelper.ReadNullSafeString(reader["address"]),
                        Telephone = DBHelper.ReadNullSafeInt(reader["telephone"].ToString()),
                        Status = DBHelper.ReadNullSafeBoolean(reader["status"].ToString()),
                        Service = new Service()
                        {
                            IdService = DBHelper.ReadNullSafeInt(reader["idService"].ToString()),
                            Name = DBHelper.ReadNullSafeString(reader["nameService"])
                        }
                    };
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

            return objDoctor;

        }

    }
}
