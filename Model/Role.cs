using System;

namespace Model
{
    public class Role
    {

        #region ATRIBUTOS
        private int idRol;
        private String name;
        #endregion

        public Role() { }

        public Role(int idRol, string name)
        {
            this.idRol = idRol;
            this.name = name;
        }

        public int IdRol { get => idRol; set => idRol = value; }
        public string Name { get => name; set => name = value; }

    }
}
