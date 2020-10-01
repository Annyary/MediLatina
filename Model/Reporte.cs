namespace Model
{
    public class Reporte
    {
        private int idReporte;
        private Pacient paciente;
        private Service servicio;
        private Farmaco farmaco;
        private Presentacion presentacion;
        private int cantidad;
        private int consumo;

        public Reporte()
        {
        }

        public Reporte(int idReporte, Pacient paciente, Service servicio, Farmaco farmaco, Presentacion presentacion, int cantidad, int consumo)
        {
            this.idReporte = idReporte;
            this.paciente = paciente;
            this.servicio = servicio;
            this.farmaco = farmaco;
            this.presentacion = presentacion;
            this.cantidad = cantidad;
            this.consumo = consumo;
        }

        public int IdReporte { get => idReporte; set => idReporte = value; }
        public Pacient Paciente { get => paciente; set => paciente = value; }
        public Service Servicio { get => servicio; set => servicio = value; }
        public Farmaco Farmaco { get => farmaco; set => farmaco = value; }
        public Presentacion Presentacion { get => presentacion; set => presentacion = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Consumo { get => consumo; set => consumo = value; }
    }
}