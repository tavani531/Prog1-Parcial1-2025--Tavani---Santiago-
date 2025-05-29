using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkManagerService
{
    public class BebidasConAlcohol:Bebidas
    {
        public int PorcentajeAlcohol { get; set; }
        public Enums.TipoBebidaAlcoholica TipoBebida { get; set; }
        public Enums.tipoEnvase TipoEnvase { get; set; }
        public DateTime FechaFabricacion { get; set; }

        
    }
}
