using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkManagerService
{
    public abstract class Bebidas
    {
        private static int ContCod = 1000;
        public int Codigo { get;private set; }
        public string Nombre { get; set; }
        public int PrecioBase { get; set; }
        public string Marca { get; set; }
        public int Volumen { get; set; }

        public Bebidas()
        {
            Codigo = ContCod;
            ContCod++;
        }
    }
}
