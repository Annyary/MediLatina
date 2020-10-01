using System;
using BusinessLogic;
using System.Web.UI;
using Utilities;
using System.Web.UI.WebControls;
using System.Linq;
using WebService;

namespace UserInterface
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CantDoctores();
                CantServicios();
                CantPacientes();
                Consumo();
            }
        }

        public void CantDoctores()
        {
            WSReporte wsreporte = new WSReporte();
            int doctores = wsreporte.CantidadDoctores();
            lblDoctores.Text = DBHelper.ReadNullSafeString(doctores);
        }

        public void CantServicios()
        {
            WSReporte wsreporte = new WSReporte();
            int servicios = wsreporte.CantidadServicios();
            lblServicios.Text = DBHelper.ReadNullSafeString(servicios);
        }

        public void CantPacientes()
        {
            WSReporte wsreporte = new WSReporte();
            int pacientes = wsreporte.CantidadPacientes();
            lblPacientes.Text = DBHelper.ReadNullSafeString(pacientes);
        }

        public void Consumo()
        {
            int consumo = 0;

            foreach (GridViewRow row in GridReportes.Rows)
            {
                consumo += DBHelper.ReadNullSafeInt(row.Cells[5].Text);
            }
            lblConsumo.Text = Convert.ToString(consumo);
        }

    }
}