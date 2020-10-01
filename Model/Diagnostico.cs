using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Diagnostico
    {
        #region ATRIBUTOS
        public int IdDiagnostico { get; set; }
        public Internado Internado { get; set; }
        public Receta receta { get; set; }
        public String Informe { get; set; }
        #endregion

        public Diagnostico() { }

        public Diagnostico(int idDiagnostico, Internado internado, Receta receta, string informe)
        {
            IdDiagnostico = idDiagnostico;
            Internado = internado;
            this.receta = receta;
            this.Informe = informe;
        }
    }
}
