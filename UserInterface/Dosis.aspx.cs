using Model;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Utilities;
using WebService;

namespace UserInterface
{
    public partial class Dosis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.divError.Visible = false;
            if (!IsPostBack)
            {
                this.divError.Visible = false;
                this.divSuccess.Visible = false;
                CargarFarmacos();
                CargarPresentacion();
            }
        }

        private Model.Dosis GetValues()
        {
            Model.Dosis objDosis = new Model.Dosis();
            objDosis.Farmaco = new Farmaco();
            objDosis.Presentacion = new Presentacion();
            objDosis.Farmaco.idVademecum = Convert.ToInt32(farmaco.SelectedValue);
            objDosis.Presentacion.idPresentacion = Convert.ToInt32(presentacion.SelectedValue);
            objDosis.Precio = DBHelper.ReadNullSafeFloat(txtPrecio.Text.Trim());
            return objDosis;
        }

        public void CargarFarmacos()
        {
            List<Farmaco> list = new List<Farmaco>();
            // ACCEDIENDO AL WEB SERVICE
            WSFarmaco wsfarmaco = new WSFarmaco();
            list = wsfarmaco.ListFarmaco();
            this.farmaco.DataSource = list;
            this.farmaco.DataValueField = "idVademecum";
            this.farmaco.DataTextField = "nombre_comercial";
            this.farmaco.DataBind();
            this.farmaco.Items.Insert(0, new ListItem("-- SELECCIONE EL FÁRMACO --"));
        }

        public void CargarPresentacion()
        {
            List<Presentacion> list = new List<Presentacion>();
            // ACCEDIENDO AL WEB SERVICE
            WSPresentacion wspresentacion = new WSPresentacion();
            list = wspresentacion.ListPresentacion();
            this.presentacion.DataSource = list;
            this.presentacion.DataValueField = "idPresentacion";
            this.presentacion.DataTextField = "tipo";
            this.presentacion.DataBind();
            this.presentacion.Items.Insert(0, new ListItem("-- SELECCIONE LA PRESENTACIÓN --"));
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            Model.Dosis objDosis = GetValues();
            // ACCEDIENDO AL WEB SERVICE
            WSDosis wsdosis = new WSDosis();
            bool response = wsdosis.InsertDosis(objDosis);
            if (response)
            {
                this.divSuccess.Visible = true;
                this.TextSuccess.Text = "¡Dosis creada con éxito!";
            }
            else
            {
                this.divError.Visible = true;
                this.TextError.Text = "¡La dosis no fue creada!";
            }
        }
    }
}