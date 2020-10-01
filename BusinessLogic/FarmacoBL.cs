using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FarmacoBL
    {
        #region "PATRON SINGLETON"
        private static FarmacoBL farmacoBL = null;
        public FarmacoBL() { }
        public static FarmacoBL GetInstance()
        {
            if (farmacoBL == null)
            {
                farmacoBL = new FarmacoBL();
            }
            return farmacoBL;
        }
        #endregion

        public bool InsertFarmaco(Farmaco objFarmaco)
        {
            try
            {
                return FarmacoConnection.GetInstance().InsertFarmaco(objFarmaco);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Farmaco> ListFarmacos()
        {
            try
            {
                return FarmacoConnection.GetInstance().ListFarmacos();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
