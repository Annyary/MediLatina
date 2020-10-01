using BusinessLogic;
using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Utilities;
using WebService;

namespace UserInterface
{
    public partial class Recetas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.divError.Visible = false;
                this.divSuccess.Visible = false;
                CargarDoctores();
                CargarFarmacos();
                CargarPresentacion();
                CargarPacientes();
                ListRecetas();
            }
        }

        public void CargarFarmacos()
        {
            List<Farmaco> list = new List<Farmaco>();
            WSFarmaco wsfarmaco = new WSFarmaco();
            list = wsfarmaco.ListFarmaco();
            this.farmaco.DataSource = list;
            this.farmaco.DataValueField = "idVademecum";
            this.farmaco.DataTextField = "nombre_comercial";
            this.farmaco.DataBind();
            this.farmaco.Items.Insert(0, new ListItem("-- Seleccione un fármaco"));
        }

        public void CargarDoctores()
        {
            List<Doctor> list = new List<Doctor>();
            WSDoctor wsdoctor = new WSDoctor();
            list = wsdoctor.ListDoctor();
            this.doctor.DataSource = list;
            this.doctor.DataValueField = "idDoctor";
            this.doctor.DataTextField = "name";
            this.doctor.DataBind();
            this.doctor.Items.Insert(0, new ListItem("-- SELECCIONE UN DOCTOR --"));
        }

        public void CargarPresentacion()
        {
            List<Presentacion> list = new List<Presentacion>();
            WSPresentacion wspresentacion = new WSPresentacion();
            list = wspresentacion.ListPresentacion();
            this.presentacion.DataSource = list;
            this.presentacion.DataValueField = "idPresentacion";
            this.presentacion.DataTextField = "tipo";
            this.presentacion.DataBind();
            this.presentacion.Items.Insert(0, new ListItem("-- Seleccione una presentación"));
        }

        public void CargarPacientes()
        {
            List<Pacient> listPacientes = new List<Pacient>();
            WSPaciente wspaciente = new WSPaciente();
            listPacientes = wspaciente.ListPaciente();
            this.paciente.DataSource = listPacientes;
            this.paciente.DataValueField = "idPacient";
            this.paciente.DataTextField = "name";
            this.paciente.DataBind();
            this.paciente.Items.Insert(0, new ListItem("-- SELECCIONE EL PACIENTE --"));
        }

        public List<Receta> ListRecetas()
        {
            List<Receta> list;
            try
            {
                WSReceta wsreceta = new WSReceta();
                list = wsreceta.ListReceta();
            }
            catch (Exception e)
            {
                throw e;
            }
            return list;
        }

        public Reporte GetValuesforReport()
        {
            Reporte objReporte = new Reporte();
            objReporte.Farmaco = new Farmaco();
            objReporte.Presentacion = new Presentacion();
            objReporte.Paciente = new Pacient();
            objReporte.Servicio = new Service();

            objReporte.IdReporte = 0;
            objReporte.Paciente.IdPacient = DBHelper.ReadNullSafeInt(this.paciente.SelectedValue);
            objReporte.Farmaco.idVademecum = DBHelper.ReadNullSafeInt(this.farmaco.SelectedValue);
            objReporte.Presentacion.idPresentacion = DBHelper.ReadNullSafeInt(this.presentacion.SelectedValue);
            objReporte.Cantidad = Convert.ToInt32(txtCantidad.Text);
            return objReporte;
        }

        public Receta GetValues()
        {
            Receta objReceta = new Receta();
            objReceta.Farmaco = new Farmaco();
            objReceta.Presentacion = new Presentacion();
            objReceta.Doctor = new Doctor();
            objReceta.Pacient = new Pacient();

            objReceta.IdReceta = 0;
            objReceta.Farmaco.idVademecum = DBHelper.ReadNullSafeInt(this.farmaco.SelectedValue);
            objReceta.Presentacion.idPresentacion = DBHelper.ReadNullSafeInt(this.presentacion.SelectedValue);
            objReceta.Doctor.IdDoctor = DBHelper.ReadNullSafeInt(this.doctor.SelectedValue);
            objReceta.Pacient.IdPacient = DBHelper.ReadNullSafeInt(this.paciente.SelectedValue);
            objReceta.Cantidad = Convert.ToInt32(txtCantidad.Text);
            objReceta.FechaEmision = Convert.ToDateTime(txtEmision.Text);
            return objReceta;
        }

        protected bool InsertReporte()
        {
            Reporte objReporte = new Reporte();
            objReporte = GetValuesforReport();
            WSReporte wsreporte = new WSReporte();
            bool response = wsreporte.InsertReporte(objReporte);
            return response;
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            // REGISTRANDO RECETA
            Receta objReceta = GetValues();
            // ACCEDIENDO AL WEB SERVICE
            WSReceta wsreceta = new WSReceta();
            bool response = wsreceta.InsertReceta(objReceta);
            if (response)
            {
                this.divSuccess.Visible = true;
                this.TextSuccess.Text = "¡Receta creada con éxito!";
                this.InsertReporte();
            }
            else
            {
                this.divError.Visible = true;
                this.TextError.Text = "¡La receta no fue creada!";
            }
        }
    }


}