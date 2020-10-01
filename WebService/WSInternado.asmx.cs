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
    public class WSInternado : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Internado> ListInternado()
        {
            try
            {
                InternadoBL internadoBL = new InternadoBL();
                return internadoBL.ListInternado();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool InsertInternado(Internado objInternado)
        {
            try
            {
                InternadoBL internadoBL = new InternadoBL();
                return internadoBL.InsertInternado(objInternado);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
