using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class InternadoBL
    {
        #region "PATRON SINGLETON"
        private static InternadoBL internadoBL = null;
        public InternadoBL() { }
        public static InternadoBL GetInstance()
        {
            if (internadoBL == null)
            {
                internadoBL = new InternadoBL();
            }
            return internadoBL;
        }
        #endregion

        public bool InsertInternado(Internado objInternado)
        {
            try
            {
                return InternadoConnection.GetInstance().InsertInternado(objInternado);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Internado> ListInternado()
        {
            try
            {
                return InternadoConnection.GetInstance().ListInternados();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
