using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkManagerService
{
    public class Ventas
    {
        public int Codigo {  get; set; }
        public string ProductoVendido { get; set; }
        public DateTime FechaOperacion { get; set; }
        public int Hora { get; set; } 
        public int Cantidad { get; set; }
        public double MontoFinal {  get; set; }

    }
}
