using BusinessLogic;
using Model;
using System;
using System.Web.Services;

namespace WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WSDosis : System.Web.Services.WebService
    {

        [WebMethod]
        public bool InsertDosis(Dosis objDosis)
        {
            try
            {
                DosisBL doctorBL = new DosisBL();
                return doctorBL.InsertDosis(objDosis);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
