using DataAccess;
using Model;
using System;

namespace BusinessLogic
{
    public class ReporteBL
    {
        #region "PATRON SINGLETON"
        private static ReporteBL reporteBL = null;
        public ReporteBL() { }
        public static ReporteBL GetInstance()
        {
            if (reporteBL == null)
            {
                reporteBL = new ReporteBL();
            }
            return reporteBL;
        }
        #endregion

        public bool InsertReporte(Reporte objReporte)
        {
            try
            {
                return ReporteConnection.GetInstance().InsertReporte(objReporte);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int CantidadDoctores()
        {
            try
            {
                return ReporteConnection.GetInstance().CantidadDoctores();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int CantidadServicios()
        {
            try
            {
                return ReporteConnection.GetInstance().CantidadServicios();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int CantidadPacientes()
        {
            try
            {
                return ReporteConnection.GetInstance().CantidadPacientes();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}