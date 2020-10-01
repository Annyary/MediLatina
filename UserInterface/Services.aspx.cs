using BusinessLogic;
using Model;
using System;
using System.Collections.Generic;
using WebService;

namespace UserInterface
{
    public partial class Services : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.divError.Visible = false;
                this.divSuccess.Visible = false;
            }
        }

        private Service GetValues()
        {
            Service objService = new Service
            {
                IdService = 0,
                Name = txtName.Text.ToUpper().Trim()
            };
            return objService;
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            //// REGISTRANDO PACIENTE
            Service objService = GetValues();
            // ACCEDIENDO AL WEB SERVICE
            WSService wsservice = new WSService();
            bool response = wsservice.InsertService(objService);
            if (response)
            {
                this.divSuccess.Visible = true;
                this.TextSuccess.Text = "¡Servicio creado con éxito!";
                this.txtName.Text = string.Empty;
            }
            else
            {
                this.divError.Visible = true;
                this.TextError.Text = "¡El servicio no fue creado!";
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            this.txtName.Text = string.Empty;
        }
    }
}