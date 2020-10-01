using BusinessLogic;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WSPresentacion : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Presentacion> ListPresentacion()
        {
            try
            {
                PresentacionBL presentacionBL = new PresentacionBL();
                return presentacionBL.ListPresentacion();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
