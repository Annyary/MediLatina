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
    public class WSService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Service> ListService()
        {
            try
            {
                ServiceBL serviceBL = new ServiceBL();
                return serviceBL.ListService();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public bool InsertService(Service objService)
        {
            try
            {
                ServiceBL serviceBL = new ServiceBL();
                return serviceBL.InsertService(objService);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
