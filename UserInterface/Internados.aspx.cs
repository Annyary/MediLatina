using Model;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using WebService;

namespace UserInterface
{
    public partial class Internados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.divSuccess.Visible = false;

            if (!Page.IsPostBack)
            {
                this.divError.Visible = false;
                this.divSuccess.Visible = false;
                this.txtIdDoctor.Visible = false;
                //Informe();
            }
        }

        protected void BtnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow grid = (GridViewRow)btn.NamingContainer;
            txtIDInternado.Text = grid.Cells[1].Text;
            txtIdDoctor.Text = grid.Cells[1].Text;
            txtPaciente.Text = grid.Cells[2].Text.ToUpper();
            txtDoctor.Text = grid.Cells[3].Text.ToUpper();
           // txtInforme.Text = grid.Cells[9].Text.ToUpper();
        }

        public Diagnostico GetValues()
        {
            Diagnostico objDiagnostico = new Diagnostico();
            objDiagnostico.Internado = new Internado();
            objDiagnostico.receta = new Receta();
            objDiagnostico.Internado.IdInternamiento = DBHelper.ReadNullSafeInt(this.txtIDInternado.Text);
            objDiagnostico.Informe = DBHelper.ReadNullSafeString(this.txtInforme.Text);
            return objDiagnostico;
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            // OBJETO DEL MODELO
            Diagnostico objDiagnostico = GetValues();
            // ACCEDIENDO AL WEB SERVICE
            WSDiagnostico wsdiagnostico = new WSDiagnostico();
            bool response = wsdiagnostico.InsertarDiagnostico(objDiagnostico);
            if (response)
            {
                this.txtDoctor.Text = string.Empty;
                this.txtIdDoctor.Text = string.Empty;
                this.txtInforme.Text = string.Empty;
                this.txtPaciente.Text = string.Empty;
                this.divSuccess.Visible = true;
                this.TextSuccess.Text = "¡Diagnóstico creado con éxito!";
            }
            else
            {
                this.divError.Visible = true;
                this.TextError.Text = "¡El diagnóstico no fue creado!";
                this.txtDoctor.Text = string.Empty;
                this.txtIdDoctor.Text = string.Empty;
                this.txtInforme.Text = string.Empty;
                this.txtPaciente.Text = string.Empty;
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            this.txtDoctor.Text = string.Empty;
            this.txtIDInternado.Text = string.Empty;
            this.txtIdDoctor.Text = string.Empty;
            this.txtInforme.Text = string.Empty;
            this.txtPaciente.Text = string.Empty;
        }
    }
}