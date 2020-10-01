using BusinessLogic;
using Model;
using System;
using UserInterface.Custom;
using WebService;

namespace UserInterface
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserSession"] = null;
            if (!IsPostBack)
            {
                this.divErrorSignIn.Visible = false;
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            WSUser wsuser = new WSUser();
            User ObjUser = wsuser.Login(txtUser.Text, txtPass.Text);
            if (ObjUser != null)
            {
                SessionManager _SessionManager = new SessionManager(Session)
                {
                    UserSession = ObjUser
                };
                Response.Redirect("/Reporte.aspx");
            }
            else
            {
                this.divErrorSignIn.Visible = true;
                this.ErrorSignInMessage.Text = "¡Usuario o clave incorrectos!";
            }
        }
    }
}