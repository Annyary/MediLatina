using DataAccess;
using Model;
using System;

namespace BusinessLogic
{
    public class UserBL
    {
        #region "PATRON SINGLETON"
        private static UserBL objUser = null;
        private UserBL() { }
        public static UserBL getInstance()
        {
            if (objUser == null)
            {
                objUser = new UserBL();
            }
            return objUser;
        }
        #endregion

        // METODO LOGIN DE USUARIO
        public User Login(String user, String pass)
        {
            try
            {
                return UserConnection.GetInstance().Login(user, pass);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
