using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class PatientConnection
    {
        #region "PATRON SINGLETON"
        private static PatientConnection patientConnection = null;
        private PatientConnection() { }
        public static PatientConnection GetInstance()
        {
            if (patientConnection == null)
            {
                patientConnection = new PatientConnection();
            }
            return patientConnection;
        }
        #endregion

        // METODO DE INSERTAR PACIENTE
        public bool InsertPatient(Pacient objPatient)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            bool response = false;
            try
            {
                connection = Connection.GetInstance().ConnectionDB();
                command = new SqlCommand("SP_INSERTPATIENT", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", objPatient.Name);
                command.Parameters.AddWithValue("@num_social", objPatient.Num_social);
                command.Parameters.AddWithValue("@address", objPatient.Address);
                command.Parameters.AddWithValue("@telephone", objPatient.Telephone);
                command.Parameters.AddWithValue("@birth", objPatient.Birth);
                command.Parameters.AddWithValue("@gender", objPatient.Gender);
                command.Parameters.AddWithValue("@status", objPatient.Status);

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

        // METODO DE LISTAR PACIENTES
        public List<Pacient> ListPatient()
        {
            List<Pacient> list = new List<Pacient>();
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;

            try
            {
                connection = Connection.GetInstance().ConnectionDB();
                command = new SqlCommand("SP_LISTARPACIENTES", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Pacient objPatient = new Pacient
                    {
                        IdPacient = Convert.ToInt32(reader["idPacient"].ToString()),
                        Num_social = Convert.ToInt32(reader["num_social"].ToString()),
                        Name = reader["name"].ToString(),
                        Telephone = Convert.ToInt32(reader["telephone"].ToString()),
                        Address = reader["address"].ToString(),
                        Birth = Convert.ToDateTime(reader["birth"].ToString()),
                        Gender = Convert.ToChar(reader["gender"]),
                        Status = Convert.ToBoolean(reader["status"].ToString())
                    };
                    // AGREGAR A LA LISTA 
                    list.Add(objPatient);
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
