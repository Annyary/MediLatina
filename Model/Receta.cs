using System;

namespace Model
{
    public class Receta
    {

        #region ATRIBUTOS
        public int IdReceta { get; set; }
        public Doctor Doctor { get; set; }
        public Farmaco Farmaco { get; set; }
        public Presentacion Presentacion { get; set; }
        public Pacient Pacient { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaEmision { get; set; }
        #endregion

        public Receta() { }

        public Receta(int idReceta, Doctor doctor, Farmaco farmaco, Presentacion presentacion, Pacient pacient, int cantidad, DateTime fechaEmision)
        {
            IdReceta = idReceta;
            Doctor = doctor;
            Farmaco = farmaco;
            Presentacion = presentacion;
            Pacient = pacient;
            Cantidad = cantidad;
            FechaEmision = fechaEmision;
        }
    }
}
