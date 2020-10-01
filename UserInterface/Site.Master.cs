using Model;
using System;
using System.Web.UI;

namespace UserInterface
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserSession"] != null)
                {
                    User objUser = (User)Session["UserSession"];
                    txtUser.Text = objUser.Email;
                } 
            }
        }
    }
}