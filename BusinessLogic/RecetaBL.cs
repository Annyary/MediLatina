using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class RecetaBL
    {
        #region "PATRON SINGLETON"
        private static RecetaBL recetaBL = null;
        public RecetaBL() { }
        public static RecetaBL GetInstance()
        {
            if (recetaBL == null)
            {
                recetaBL = new RecetaBL();
            }
            return recetaBL;
        }
        #endregion

        public bool InsertReceta(Receta objReceta)
        {
            try
            {
                return RecetaConnection.GetInstance().InsertReceta(objReceta);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Receta> ListReceta()
        {
            try
            {
                return RecetaConnection.GetInstance().ListReceta();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
