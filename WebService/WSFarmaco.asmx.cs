using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Web.Services;

namespace WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WSFarmaco : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Farmaco> ListFarmaco()
        {
            try
            {
                FarmacoBL farmacoBL = new FarmacoBL();
                return farmacoBL.ListFarmacos();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public bool InsertFarmaco(Farmaco objFarmaco)
        {
            try
            {
                FarmacoBL internadoBL = new FarmacoBL();
                return internadoBL.InsertFarmaco(objFarmaco);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
