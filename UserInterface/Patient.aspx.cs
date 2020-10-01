using BusinessLogic;
using Model;
using System;
using System.Collections.Generic;
using System.Web.Services;
using WebService;

namespace UserInterface
{
    public partial class Patient : System.Web.UI.Page
    {
        private Pacient objPatient;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.divError.Visible = false;
            if (!Page.IsPostBack)
            {
                this.divError.Visible = false;
                this.divSuccess.Visible = false;
            }
        }

        private Pacient GetValues()
        {
                objPatient = new Pacient
                {
                    IdPacient = 0,
                    Name = txtName.Text.ToUpper().Trim(),
                    Num_social = Convert.ToInt32(txtNumSocial.Text.ToUpper().Trim()),
                    Address = txtAddress.Text.ToUpper().Trim(),
                    Birth = Convert.ToDateTime(txtBirth.Text),
                    Gender = (gender.SelectedValue == "Femenino") ? 'F' : 'M',
                    Status = true
                };
            return objPatient;
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            // REGISTRANDO PACIENTE
            Pacient objPatient = GetValues();
            // ACCEDIENDO AL WEB SERVICE 
            WSPaciente wspaciente = new WSPaciente();
            bool response = wspaciente.InsertPaciente(objPatient);
            if (response)
            {
                this.divSuccess.Visible = true;
                this.TextSuccess.Text = "¡Paciente creado con éxito!";
                this.txtName.Text = string.Empty;
                this.txtNumSocial.Text = string.Empty;
                this.txtAddress.Text = string.Empty;
                this.txtBirth.Text = string.Empty;
                this.gender.Items.Clear();
            }
            else
            {
                this.divError.Visible = true;
                this.TextError.Text = "¡El paciente no fue creado!";
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            this.txtName.Text = string.Empty;
            this.txtNumSocial.Text = string.Empty;
            this.txtAddress.Text = string.Empty;
            this.txtBirth.Text = string.Empty;
            this.gender.Items.Clear();
        }

        protected void PatientPageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
        }
    }
}