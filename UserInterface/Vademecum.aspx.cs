using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Web.UI;
using Utilities;
using WebService;

namespace UserInterface
{
    public partial class Vademecum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.divError.Visible = false;
                this.divSuccess.Visible = false;
                ListVademecum();
            }
        }

        public List<Farmaco> ListVademecum()
        {
            List<Farmaco> list;
            try
            {
                WSFarmaco wsfarmaco = new WSFarmaco();
                list = wsfarmaco.ListFarmaco();
            }
            catch (Exception e)
            {
                throw e;
            }
            return list;
        }

        private Farmaco GetValues()
        {
            Farmaco objFarmaco = new Farmaco
            {
                idVademecum = 0,
                num_registro = DBHelper.ReadNullSafeString(txtNumRegistro.Text),
                nombre_comercial = DBHelper.ReadNullSafeString(txtNombreComercial.Text),
                nombre_clinico = DBHelper.ReadNullSafeString(txtNombreClinico.Text),
                compuesto_quimico = DBHelper.ReadNullSafeString(txtCompuestoQuimico.Text),
                ubicacion = DBHelper.ReadNullSafeString(txtUbicacion.Text),
                proveedor = DBHelper.ReadNullSafeString(txtProveedor.Text)
            };
            return objFarmaco;
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            // REGISTRO DE VADEMECUM
            Farmaco objFarmaco = GetValues();
            WSFarmaco wsfarmaco = new WSFarmaco();
            bool response = wsfarmaco.InsertFarmaco(objFarmaco);
            if (response)
            {
                this.divSuccess.Visible = true;
                this.TextSuccess.Text = "¡Fármaco creado con éxito!";
            }
            else
            {
                this.divError.Visible = true;
                this.TextError.Text = "¡El fármaco no fue creado!";
            }
        }
    }
}