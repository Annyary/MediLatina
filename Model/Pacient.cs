using System;

namespace Model
{
    public class Pacient
    {

        #region ATRIBUTOS
        private int idPacient;
        private String name;
        private int num_social;
        private String address;
        private int telephone;
        private DateTime birth;
        private char gender;
        private bool status;
        #endregion

        public Pacient() { }

        public Pacient(int idPacient, string name, int num_social, string address, int telephone, DateTime birth, char gender, bool status)
        {
            this.idPacient = idPacient;
            this.name = name;
            this.num_social = num_social;
            this.address = address;
            this.telephone = telephone;
            this.birth = birth;
            this.gender = gender;
            this.status = status;
        }

        public int IdPacient { get => idPacient; set => idPacient = value; }
        public string Name { get => name; set => name = value; }
        public int Num_social { get => num_social; set => num_social = value; }
        public string Address { get => address; set => address = value; }
        public int Telephone { get => telephone; set => telephone = value; }
        public DateTime Birth { get => birth; set => birth = value; }
        public char Gender { get => gender; set => gender = value; }
        public bool Status { get => status; set => status = value; }
    }
}
