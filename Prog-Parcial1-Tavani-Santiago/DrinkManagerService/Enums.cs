using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkManagerService
{
    public class Enums
    {
        public enum TipoBebidaAlcoholica
        {
            Cerveza,
            Vino,
            Whisky,    
        }
        public enum  tipoEnvase
        {
            Vidrio,
            Plastico,
            Lata
        }
        public enum SaborBebidaSinAlcohol
        {
            SinSabor,
            LimaLimon,
            Cola,
            Naranja
        }
        public enum NivelAzucarEnergizante
        {
            Bajo,
            Medio,
            Alto
        }
    }
}
