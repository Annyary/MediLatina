using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Dosis
    {
        public Farmaco Farmaco { get; set; }
        public Presentacion Presentacion { get; set; }
        public float Precio { get; set; }

        public Dosis() { }

        public Dosis(Farmaco farmaco, Presentacion presentacion, float precio)
        {
            Farmaco = farmaco;
            Presentacion = presentacion;
            Precio = precio;
        }
    }
}
