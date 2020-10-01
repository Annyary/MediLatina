using Model;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using WebService;

namespace UserInterface
{
    public partial class Doctors : System.Web.UI.Page
    {
        TextBoxValidation validation = new TextBoxValidation();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                this.divError.Visible = false;
                this.divSuccess.Visible = false;
                this.CargarServicios();
            }
        }

        public List<Doctor> ListDoctors()
        {
            List<Doctor> list;
            try
            {
                // ACCEDIENDO AL WEB SERVICE
                WSDoctor wsdoctor = new WSDoctor();
                list = wsdoctor.ListDoctor();
            }
            catch (Exception e)
            {
                throw e;
            }
            return list;
        }


        public Doctor GetValues()
        {
            Doctor objDoctor = new Doctor();
            objDoctor.Service = new Service();
            objDoctor.IdDoctor = 0;
            objDoctor.Num_colegiado = Convert.ToInt32(txtNumColegiado.Text);
            objDoctor.Name = txtName.Text;
            objDoctor.Address = txtAddress.Text;
            objDoctor.Telephone = Convert.ToInt32(txtTelephone.Text);
            objDoctor.Service.IdService = Convert.ToInt32(this.service.SelectedValue);
            objDoctor.Status = true;
            return objDoctor;
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            // OBTENIENDO LOS DATOS DEL DOCTOR
            Doctor objDoctor = GetValues();
            // ACCEDIENDO AL WEB SERVICE
            WSDoctor wsdoctor = new WSDoctor();
            bool response = wsdoctor.InsertDoctor(objDoctor);
            if (response)
            {
                this.divSuccess.Visible = true;
                this.TextSuccess.Text = "¡Doctor creado con éxito!";
                this.txtNumColegiado.Text = string.Empty;
                this.txtName.Text = string.Empty;
                this.txtAddress.Text = string.Empty;
                this.txtTelephone.Text = string.Empty;
                this.service.Items.Clear();
                CargarServicios();
            }
            else
            {
                this.divError.Visible = true;
                this.TextError.Text = "¡El doctor no fue creado!";
            }
        }
        public void CargarServicios()
        {
            List<Service> listService = new List<Service>();
            WSService wsservice = new WSService();
            listService = wsservice.ListService();
            this.service.DataSource = listService;
            this.service.DataValueField = "idService";
            this.service.DataTextField = "name";
            this.service.DataBind();
            this.service.Items.Insert(0, new ListItem("-- SELECCIONE EL SERVICIO --"));
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            this.txtNumColegiado.Text = string.Empty;
            this.txtName.Text = string.Empty;
            this.txtAddress.Text = string.Empty;
            this.txtTelephone.Text = string.Empty;
            this.service.Items.Clear();
            CargarServicios();
        }
    }
}