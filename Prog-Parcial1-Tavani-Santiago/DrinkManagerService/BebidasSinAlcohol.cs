using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkManagerService
{
    public class BebidasSinAlcohol:Bebidas
    {
        public Enums.SaborBebidaSinAlcohol Sabor { get; set; }
        public bool Gasificada { get; set; }
        public bool AptoDiabeticos { get; set; }
        public bool Colorantes { get; set; }

    }
}
