using BusinessLogic;
using Model;
using System;
using System.Collections.Generic;
using System.Web.Services;

namespace WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WSReceta : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Receta> ListReceta()
        {
            try
            {
                RecetaBL recetaBL = new RecetaBL();
                return recetaBL.ListReceta();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool InsertReceta(Receta objReceta)
        {
            try
            {
                RecetaBL recetaBL = new RecetaBL();
                return recetaBL.InsertReceta(objReceta);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
