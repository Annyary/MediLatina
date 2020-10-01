using System;

namespace Model
{
    public class Doctor
    {
        private int idDoctor;
        private int num_colegiado;
        private String name;
        private String address;
        private int telephone;
        private Service service;
        private bool status;
        
        public Doctor() { }

        public Doctor(int idDoctor, int num_colegiado, string name, string address, int telephone, Service service, bool status)
        {
            this.idDoctor = idDoctor;
            this.num_colegiado = num_colegiado;
            this.name = name;
            this.address = address;
            this.telephone = telephone;
            this.service = service;
            this.status = status;
        }

        public int IdDoctor { get => idDoctor; set => idDoctor = value; }
        public int Num_colegiado { get => num_colegiado; set => num_colegiado = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public int Telephone { get => telephone; set => telephone = value; }
        public Service Service { get => service; set => service = value; }
        public bool Status { get => status; set => status = value; }
    }
}
