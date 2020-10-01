using Model;
using System.Web.SessionState;

namespace UserInterface.Custom
{
    public class SessionManager
    {

        #region variables
        private HttpSessionState _currentSession;
        #endregion

        public SessionManager(HttpSessionState session)
        {
            this._currentSession = session;
        }

        #region metodos
        private HttpSessionState CurrentSession
        {
            get { return this._currentSession; }
        }

        public User UserSession
        {
            set { CurrentSession["UserSession"] = value; }
            get { return (User)CurrentSession["UserSession"]; }
        }

        #endregion

    }
}