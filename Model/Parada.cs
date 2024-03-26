using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project._04_LineasAutobuses.Model
{
    public class Parada
    {
        public long NumeroLinea { get; set; }
        public int OrdenParada { get; set; }
        public string Municipio { get; set; }
        public TimeSpan HoraLlegada { get; set; }
    }
}
