using BusinessLogic;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService
{
    /// <summary>
    /// Summary description for WSPaciente
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WSPaciente : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Pacient> ListPaciente()
        {
            try
            {
                PatientBL pacienteBL = new PatientBL();
                return pacienteBL.ListPatients();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool InsertPaciente(Pacient objPaciente)
        {
            try
            {
                PatientBL pacienteBL = new PatientBL();
                return pacienteBL.InsertPatient(objPaciente);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
