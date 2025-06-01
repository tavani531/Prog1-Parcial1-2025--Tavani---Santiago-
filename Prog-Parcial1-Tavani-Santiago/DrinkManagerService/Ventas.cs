using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkManagerService
{
    public class Ventas
    {
        //CORRECCION: EL CODIGO NO DEBE SER ESTATICO
        public int Codigo {  get; set; }
        //CORRECCION: DEBE SER UNA REFERENCIA A LA BEBIDA Y NO UN STRING
        public string ProductoVendido { get; set; }
        public DateTime FechaOperacion { get; set; }
        //CORRECCION: NO SE DEBE ALMACENAR LA HORA POR SEPARADO
        public int Hora { get; set; } 
        public int Cantidad { get; set; }
        public double MontoFinal {  get; set; }
    }
}
