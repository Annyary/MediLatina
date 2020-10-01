using DataAccess;
using Model;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class DoctorBL
    {
        #region "PATRON SINGLETON"
        private static DoctorBL doctorBL = null;
        public DoctorBL() { }
        public static DoctorBL GetInstance()
        {
            if (doctorBL == null)
            {
                doctorBL = new DoctorBL();
            }
            return doctorBL;
        }
        #endregion

        public bool InsertDoctor(Doctor objDoctor)
        {
            try
            {
                return DoctorConnection.GetInstance().InsertDoctor(objDoctor);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    
        public List<Doctor> ListDoctors()
        {
            try
            {
                return DoctorConnection.GetInstance().ListDoctors();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Doctor> ListDoctorPorServicio(Doctor objDoctor)
        {
            try
            {
                return DoctorConnection.GetInstance().ListDoctorPorServicio(objDoctor);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Doctor BuscarDoctor(String id)
        {
            try
            {
                return DoctorConnection.GetInstance().BuscarDoctor(id);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
