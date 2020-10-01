using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class DosisBL
    {
        #region "PATRON SINGLETON"
        private static DosisBL dosisBL = null;
        public DosisBL() { }
        public static DosisBL GetInstance()
        {
            if (dosisBL == null)
            {
                dosisBL = new DosisBL();
            }
            return dosisBL;
        }
        #endregion

        public bool InsertDosis(Dosis objDosis)
        {
            try
            {
                return DosisConnection.GetInstance().InsertDosis(objDosis);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
