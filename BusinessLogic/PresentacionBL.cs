using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class PresentacionBL
    {

        #region "PATRON SINGLETON"
        private static PresentacionBL presentacionBL = null;
        public PresentacionBL() { }
        public static PresentacionBL GetInstance()
        {
            if (presentacionBL == null)
            {
                presentacionBL = new PresentacionBL();
            }
            return presentacionBL;
        }
        #endregion

        public List<Presentacion> ListPresentacion()
        {
            try
            {
                return PresentacionConnection.GetInstance().ListPresentacion();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool InsertPresentacion(Presentacion objPresentacion)
        {
            try
            {
                return PresentacionConnection.GetInstance().InsertPresentacion(objPresentacion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
