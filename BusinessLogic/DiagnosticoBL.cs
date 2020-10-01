using DataAccess;
using Model;
using System;

namespace BusinessLogic
{
    public class DiagnosticoBL
    {
        #region "PATRON SINGLETON"
        private static DiagnosticoBL diagnosticoBL = null;
        public DiagnosticoBL() { }
        public static DiagnosticoBL GetInstance()
        {
            if (diagnosticoBL == null)
            {
                diagnosticoBL = new DiagnosticoBL();
            }
            return diagnosticoBL;
        }
        #endregion

        public bool InsertDiagnostico(Diagnostico objDiagnostico)
        {
            try
            {
                return DiagnosticoConnection.GetInstance().InsertDiagnostico(objDiagnostico);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool LeerInforme(Diagnostico objDiagnostico)
        {
            try
            {
                return DiagnosticoConnection.GetInstance().LeerInforme(objDiagnostico);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
