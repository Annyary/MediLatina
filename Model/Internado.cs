using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Internado
    {
        #region ATRIBUTOS
        private int idInternamiento;
        private Pacient paciente;
        private Service servicio;
        private DateTime fechaIngreso;
        private DateTime fechaSalida;
        public Diagnostico Diagnostico { get; set; }
        #endregion

        public Internado() { }

        public Internado(int idInternamiento, Pacient paciente, Service servicio, DateTime fechaIngreso, DateTime fechaSalida, Diagnostico diagnostico)
        {
            this.idInternamiento = idInternamiento;
            this.paciente = paciente;
            this.servicio = servicio;
            this.fechaIngreso = fechaIngreso;
            this.fechaSalida = fechaSalida;
            Diagnostico = diagnostico;
        }

        public int IdInternamiento { get => idInternamiento; set => idInternamiento = value; }
        public Pacient Paciente { get => paciente; set => paciente = value; }
        public Service Servicio { get => servicio; set => servicio = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public DateTime FechaSalida { get => fechaSalida; set => fechaSalida = value; }
    }
}
