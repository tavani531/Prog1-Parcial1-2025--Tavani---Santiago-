using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkManagerService
{
    public class BebidasEnergizantes:Bebidas
    {
        public bool AptoDeportistas { get; set; }
        public Enums.NivelAzucarEnergizante NivelAzucar { get; set; }
    }
}
