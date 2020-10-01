using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Presentacion
    {
        public int idPresentacion { get; set; }
        public String tipo { get; set; }

        public Presentacion() { }

        public Presentacion(int idPresentacion, string tipo)
        {
            this.idPresentacion = idPresentacion;
            this.tipo = tipo;
        }

    }
}
