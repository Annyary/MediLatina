using BusinessLogic;
using Model;
using System;
using System.Web.Services;

namespace WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WSReporte : System.Web.Services.WebService
    {

        [WebMethod]
        public int CantidadDoctores()
        {
            try
            {
                ReporteBL reporteBL = new ReporteBL();
                return reporteBL.CantidadDoctores();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public int CantidadServicios()
        {
            try
            {
                ReporteBL reporteBL = new ReporteBL();
                return reporteBL.CantidadServicios();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [WebMethod]
        public int CantidadPacientes()
        {
            try
            {
                ReporteBL reporteBL = new ReporteBL();
                return reporteBL.CantidadPacientes();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public bool InsertReporte(Reporte objReporte)
        {
            try
            {
                ReporteBL reporteBL = new ReporteBL();
                return reporteBL.InsertReporte(objReporte);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
