using DataAccess;
using Model;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class PatientBL
    {
        #region "PATRON SINGLETON"
        private static PatientBL patientBL = null;
        public PatientBL() { }
        public static PatientBL GetInstance()
        {
            if (patientBL == null)
            {
                patientBL = new PatientBL();
            }
            return patientBL;
        }
        #endregion

        public bool InsertPatient(Pacient objPatient)
        {
            try
            {
                return PatientConnection.GetInstance().InsertPatient(objPatient);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Pacient> ListPatients()
        {
            try
            {
                return PatientConnection.GetInstance().ListPatient();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
