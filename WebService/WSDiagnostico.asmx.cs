using BusinessLogic;
using Model;
using System.Web.Services;

namespace WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WSDiagnostico : System.Web.Services.WebService
    {

        [WebMethod]
        public bool InsertarDiagnostico(Diagnostico objDiagnostico)
        {
            DiagnosticoBL diagnosticoBL = new DiagnosticoBL();
            return diagnosticoBL.InsertDiagnostico(objDiagnostico);
        }

        [WebMethod]
        public bool LeerInforme(Diagnostico objDiagnostico)
        {
            DiagnosticoBL diagnosticoBL = new DiagnosticoBL();
            return diagnosticoBL.LeerInforme(objDiagnostico);
        }
    }
}
