using DataAccess;
using Model;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class ServiceBL
    {
        #region "PATRON SINGLETON"
        private static ServiceBL serviceBL = null;
        public ServiceBL() { }
        public static ServiceBL GetInstance()
        {
            if (serviceBL == null)
            {
                serviceBL = new ServiceBL();
            }
            return serviceBL;
        }
        #endregion

        public bool InsertService(Service objService)
        {
            try
            {
                return ServiceConnection.GetInstance().InsertService(objService);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Service> ListService()
        {
            try
            {
                return ServiceConnection.GetInstance().ListService();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
