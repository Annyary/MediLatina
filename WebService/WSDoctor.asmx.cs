using BusinessLogic;
using Model;
using System;
using System.Collections.Generic;
using System.Web.Services;

namespace WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WSDoctor : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Doctor> ListDoctor()
        {
            try
            {
                DoctorBL doctorBL = new DoctorBL();
                return doctorBL.ListDoctors();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public List<Doctor> ListDoctorPorServicio(Doctor objDoctor)
        {
            try
            {
                DoctorBL doctorBL = new DoctorBL();
                return doctorBL.ListDoctorPorServicio(objDoctor);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public bool InsertDoctor(Doctor objDoctor)
        {
            try
            {
                DoctorBL doctorBL = new DoctorBL();
                return doctorBL.InsertDoctor(objDoctor);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        
    }
}
