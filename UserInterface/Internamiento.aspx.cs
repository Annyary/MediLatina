using BusinessLogic;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using WebService;

namespace UserInterface
{
    public partial class Internamiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.divSuccess.Visible = false;
            if (!IsPostBack)
            {
                this.divSuccess.Visible = false;
                this.divError.Visible = false;
                CargarPacientes();
                CargarServicios();
            }

        }

        public List<Internado> ListInternado()
        {
            List<Internado> list;
            try
            {
                // ACCEDIENDO AL WEB SERVICE
                WSInternado wsinternado = new WSInternado();
                list = wsinternado.ListInternado();
            }
            catch (Exception e)
            {
                throw e;
            }
            return list;
        }

        public Internado GetValues()
        {
            Internado objInternado = new Internado();
            objInternado.Paciente = new Pacient();
            objInternado.Servicio = new Service();

            objInternado.IdInternamiento = 0;
            objInternado.Paciente.IdPacient = DBHelper.ReadNullSafeInt(this.paciente.SelectedValue);
            objInternado.Servicio.IdService = DBHelper.ReadNullSafeInt(this.servicio.SelectedValue);
            objInternado.FechaIngreso = Convert.ToDateTime(fechaIngreso.Text);
            //objInternado.FechaSalida = Convert.ToDateTime(fechaSalida.Text);
            return objInternado;
        }

        public void CargarServicios()
        {
            List<Service> listService = new List<Service>();
            WSService wsservice = new WSService();
            listService = wsservice.ListService();
            this.servicio.DataSource = listService;
            this.servicio.DataValueField = "idService";
            this.servicio.DataTextField = "name";
            this.servicio.DataBind();
            this.servicio.Items.Insert(0, new ListItem("-- SELECCIONE EL SERVICIO --"));
        }

        protected void ServicioSeleccionado(object sender, EventArgs e)
        {
            Doctor objDoctor = new Doctor();
            objDoctor.Service = new Service();
            objDoctor.Service.IdService = DBHelper.ReadNullSafeInt(this.servicio.SelectedValue);
            //this.CargarDoctores(objDoctor);
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

        //public void CargarDoctores(Doctor objDoctor)
        //{
        //    List<Doctor> listDoctores = new List<Doctor>();
        //    WSDoctor wsdoctor = new WSDoctor();
        //    listDoctores = wsdoctor.ListDoctorPorServicio(objDoctor);
        //    this.doctor.DataSource = listDoctores;
        //    this.doctor.DataValueField = "idDoctor";
        //    this.doctor.DataTextField = "name";
        //    this.doctor.DataBind();
        //    this.doctor.Items.Insert(0, new ListItem("-- SELECCIONE EL DOCTOR --"));
        //}

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            // REGISTRANDO INTERNADO
            Internado objInternado = GetValues();
            // ACCEDIENDO AL WEB SERVICE
            WSInternado wsinternado = new WSInternado();
            bool response = wsinternado.InsertInternado(objInternado);
            if (response)
            {
                this.divSuccess.Visible = true;
                this.TextSuccess.Text = "¡Internamiento realizado con éxito!";
                this.paciente.Items.Clear();
                this.servicio.Items.Clear();
                this.fechaIngreso.Text = string.Empty;
                CargarServicios();
                CargarPacientes();
            }
            else
            {
                this.divError.Visible = true;
                this.TextError.Text = "¡El internamiento no fue realizado!";
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            this.paciente.Items.Clear();
            this.servicio.Items.Clear();
            this.fechaIngreso.Text = string.Empty;
            CargarServicios();
            CargarPacientes();
        }


    }
}