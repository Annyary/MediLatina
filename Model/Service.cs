using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Service
    {
        #region ATRIBUTOS
        private int idService;
        private String name;
        #endregion

        public Service() { }

        public Service(int idService, string name)
        {
            this.idService = idService;
            this.name = name;
        }

        public int IdService { get => idService; set => idService = value; }
        public string Name { get => name; set => name = value; }
    }
}
