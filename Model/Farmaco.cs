using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Farmaco
    {
        public int idVademecum { get; set; }
        public String num_registro { get; set; }
        public String nombre_comercial { get; set; }
        public String nombre_clinico { get; set; }
        public String compuesto_quimico { get; set; }
        public String ubicacion { get; set; }
        public String proveedor { get; set; }

        public Farmaco() { }

        public Farmaco(int idVademecum, string num_registro, string nombre_comercial, string nombre_clinico, string compuesto_quimico, string ubicacion, string proveedor)
        {
            this.idVademecum = idVademecum;
            this.num_registro = num_registro;
            this.nombre_comercial = nombre_comercial;
            this.nombre_clinico = nombre_clinico;
            this.compuesto_quimico = compuesto_quimico;
            this.ubicacion = ubicacion;
            this.proveedor = proveedor;
        }

    }
}
